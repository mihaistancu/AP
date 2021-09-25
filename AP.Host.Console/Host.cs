using AP.Antimalware.Amsi;
using AP.AS4;
using AP.CDM;
using AP.Certificates;
using AP.Configuration.API;
using AP.Configuration.API.Routing;
using AP.Cryptography;
using AP.Gateways.AP;
using AP.Gateways.CSN;
using AP.Gateways.Institution;
using AP.IR;
using AP.IR.Request;
using AP.IR.Subscriptions;
using AP.Messaging.Client;
using AP.Messaging.Queue;
using AP.Messaging.Service;
using AP.Middleware.RabbitMQ;
using AP.Monitoring;
using AP.Processing.Async;
using AP.Processing.Async.Antimalware;
using AP.Processing.Async.DocumentValidation;
using AP.Processing.Async.Forwarding;
using AP.Processing.Async.Synchronization.CDM.Import;
using AP.Processing.Async.Synchronization.CDM.Report;
using AP.Processing.Async.Synchronization.CDM.Request;
using AP.Processing.Async.Synchronization.CDM.Subscriptions;
using AP.Processing.Async.Synchronization.IR.Import;
using AP.Processing.Async.Synchronization.IR.Request;
using AP.Processing.Async.Synchronization.IR.Subscriptions;
using AP.Processing.Sync;
using AP.Processing.Sync.AsyncProcessing;
using AP.Processing.Sync.Decryption;
using AP.Processing.Sync.EnvelopeValidation;
using AP.Processing.Sync.Persistence;
using AP.Processing.Sync.PullRequest;
using AP.Processing.Sync.Receipt;
using AP.Processing.Sync.SignatureValidation;
using AP.Processing.Sync.TlsCertificateValidation;
using AP.Routing;
using AP.Signing;
using AP.Storage;
using AP.Validation;
using AP.Web.Server.Owin;
using System;

namespace AP.Host.Console
{
    public class Host
    {
        private bool isMonitoringEnabled;

        public Orchestrator Orchestrator { get; private set; }
        public MessageServer MessageServer { get; private set; }
        public ConfigurationServer ConfigurationServer { get; private set; }
        
        public void SetMonitoring(bool isMonitoringEnabled)
        {
            this.isMonitoringEnabled = isMonitoringEnabled;
        }

        public void RegisterDependencies()
        {
            var messageStorage = new MessageStorage();
            
            var messageClient = isMonitoringEnabled 
                ? new MonitoredMessageClient() 
                : new MessageClient();

            var messageQueue = isMonitoringEnabled 
                ? new MonitoredMessageQueue() 
                : new MessageQueue();

            var csnGateway = new CsnGateway(new CsnConfig(), messageClient);
            var apGateway = new ApGateway(new Encryptor(), new ApConfig(), messageClient);
            var institutionGateway = new InstitutionGateway(new RoutingConfig(), messageClient, messageQueue);

            var scanner = new AmsiScanner();
            var antimalwareErrorFactory = new AntimalwareErrorFactory();
            var scanMessageFromCsn = Worker(new AntimalwareWorker(scanner, antimalwareErrorFactory, messageStorage, csnGateway));
            var scanMessageFromAp = Worker(new AntimalwareWorker(scanner, antimalwareErrorFactory, messageStorage, apGateway));
            var scanMessageFromInstitution = Worker(new AntimalwareWorker(scanner, antimalwareErrorFactory, messageStorage, institutionGateway));

            var documentValidator = new DocumentValidator();
            var documentValidationErrorFactory = new DocumentValidationErrorFactory();
            var validateDocumentFromCsn = Worker(new DocumentValidationWorker(documentValidator, documentValidationErrorFactory, messageStorage, csnGateway));
            var validateDocumentFromAp = Worker(new DocumentValidationWorker(documentValidator, documentValidationErrorFactory, messageStorage, apGateway));
            var validateDocumentFromInstitution = Worker(new DocumentValidationWorker(documentValidator, documentValidationErrorFactory, messageStorage, institutionGateway));

            var forwardToAp = new ForwardingWorker(apGateway);
            var forwardToInstitution = new ForwardingWorker(institutionGateway);
            var cdmStorage = new CdmStorage();
            var importCdm = Worker(new CdmImportWorker(new CdmImporter()));
            var reportCdm = Worker(new CdmReportWorker(new CdmReporter(), csnGateway));
            var provideCdm = Worker(new CdmRequestWorker(new CdmProvider(new CdmRequestParser(), cdmStorage, messageStorage, csnGateway)));
            var publishCdm = Worker(new CdmSubscriptionsWorker(new CdmPublisher(new CdmSubscriptionStorage(), cdmStorage, messageStorage, institutionGateway)));

            var irStorage = new IrStorage();
            var importIr = Worker(new IrImportWorker(new IrImporter()));
            var provideIr = Worker(new IrRequestWorker(new IrProvider(new IrRequestParser(), irStorage, messageStorage, institutionGateway)));
            var publishIr = Worker(new IrSubscriptionsWorker(new IrPublisher(new IrSubscriptionStorage(), irStorage, messageStorage, institutionGateway)));
            
            Func<string, IWorker> getWorker = name =>
            {
                switch (name)
                {
                    case Workers.ScanMessageFromCsn: return scanMessageFromCsn;
                    case Workers.ScanMessageFromAp: return scanMessageFromAp;
                    case Workers.ScanMessageFromInstitution: return scanMessageFromInstitution;
                    case Workers.ValidateDocumentFromCsn: return validateDocumentFromCsn;
                    case Workers.ValidateDocumentFromAp: return validateDocumentFromAp;
                    case Workers.ValidateDocumentFromInstitution: return validateDocumentFromInstitution;
                    case Workers.ForwardToAp: return forwardToAp;
                    case Workers.ForwardToInstitution: return forwardToInstitution;
                    case Workers.ImportCdm: return importCdm;
                    case Workers.ReportCdm: return reportCdm;
                    case Workers.ProvideCdm: return provideCdm;
                    case Workers.PublishCdm: return publishCdm;
                    case Workers.ImportIr: return importIr;
                    case Workers.ProvideIr: return provideIr;
                    case Workers.PublishIr: return publishIr;
                }
                throw new Exception("Uknown worker");
            };

            Orchestrator = new Orchestrator(new OrchestratorConfig(), messageStorage, new MessageBroker(new RabbitMqBroker()), getWorker);

            var processAsync = Handler(new AsyncProcessingHandler(Orchestrator));
            var decrypt = Handler(new DecryptionHandler(new Decryptor()));
            var validateEnvelope = Handler(new EnvelopeValidationHandler(new EnvelopeValidator(), new EnvelopeValidationErrorFactory()));
            var persist = Handler(new PersistenceHandler(messageStorage));
            var pullRequest = Handler(new PullRequestHandler(new MessageProvider(messageQueue)));
            var receipt = Handler(new ReceiptHandler(new ReceiptFactory()));
            var validateSignature = Handler(new SignatureValidationHandler(new EnvelopeSignatureValidator(), new EnvelopeSignatureValidationErrorFactory()));
            var validateTlsCertificate = Handler(new TlsCertificateValidationHandler(new CertificateValidator(), new TlsCertificateValidationErrorFactory()));

            Func<string, IHandler> getHandler = name =>
            {
                switch (name)
                {
                    case Handlers.ProcessAsync: return processAsync;
                    case Handlers.Decrypt: return decrypt;
                    case Handlers.ValidateEnvelope: return validateEnvelope;
                    case Handlers.Persist: return persist;
                    case Handlers.PullRequest: return pullRequest;
                    case Handlers.Receipt: return receipt;
                    case Handlers.ValidateSignature: return validateSignature;
                    case Handlers.ValidateTlsCertificate: return validateTlsCertificate;
                }
                throw new Exception("Uknown worker");
            };

            MessageServer = new MessageServer(new OwinWebServer(), getHandler);
            
            var routingRuleStorage = new RoutingRuleStorage();
            ConfigurationServer = new ConfigurationServer(
                new OwinWebServer(), 
                new GetAllRoutingRulesApi(routingRuleStorage),
                new AddRoutingRuleApi(routingRuleStorage),
                new UpdateRoutingRuleApi(routingRuleStorage),
                new DeleteRoutingRuleApi(routingRuleStorage));
        }

        private IHandler Handler(IHandler handler)
        {
            return isMonitoringEnabled ? new MonitoredHandler(handler) : handler;
        }

        private IWorker Worker(IWorker worker)
        {
            return isMonitoringEnabled ? new MonitoredWorker(worker) : worker;
        }
    }
}
