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
            var handlerFactory = new HandlerFactory();
            var workerFactory = new WorkerFactory();
            var messageStorage = new MessageStorage();
            
            Orchestrator = new Orchestrator(new OrchestratorConfig(), messageStorage, new MessageBroker(new RabbitMqBroker()), workerFactory);

            var messageClient = isMonitoringEnabled 
                ? new MonitoredMessageClient() 
                : new MessageClient();

            var messageQueue = isMonitoringEnabled 
                ? new MonitoredMessageQueue() 
                : new MessageQueue();

            var csnGateway = new CsnGateway(new CsnConfig(), messageClient);
            var apGateway = new ApGateway(new Encryptor(), new ApConfig(), messageClient);
            var institutionGateway = new InstitutionGateway(new RoutingConfig(), messageClient, messageQueue);

            var processAsync = new AsyncProcessingHandler(Orchestrator);
            handlerFactory.Set(Handlers.ProcessAsync, Handler(processAsync));
            
            var decrypt = new DecryptionHandler(new Decryptor());
            handlerFactory.Set(Handlers.Decrypt, Handler(decrypt));
            
            var validateEnvelope = new EnvelopeValidationHandler(new EnvelopeValidator(), new EnvelopeValidationErrorFactory());
            handlerFactory.Set(Handlers.ValidateEnvelope, Handler(validateEnvelope));
            
            var persist = new PersistenceHandler(messageStorage);
            handlerFactory.Set(Handlers.Persist, Handler(persist));
            
            var pullRequest = new PullRequestHandler(new MessageProvider(messageQueue));
            handlerFactory.Set(Handlers.PullRequest, Handler(pullRequest));
            
            var receipt = new ReceiptHandler(new ReceiptFactory());
            handlerFactory.Set(Handlers.Receipt, Handler(receipt));
            
            var validateSignature = new SignatureValidationHandler(new EnvelopeSignatureValidator(), new EnvelopeSignatureValidationErrorFactory());
            handlerFactory.Set(Handlers.ValidateSignature, Handler(validateSignature));
            
            var validateTlsCertificate = new TlsCertificateValidationHandler(new CertificateValidator(), new TlsCertificateValidationErrorFactory());
            handlerFactory.Set(Handlers.ValidateTlsCertificate, Handler(validateTlsCertificate));

            var scanner = new AmsiScanner();
            var antimalwareErrorFactory = new AntimalwareErrorFactory();
            var scanMessageFromCsn = new AntimalwareWorker(scanner, antimalwareErrorFactory, messageStorage, csnGateway);
            workerFactory.Set(Workers.ScanMessageFromCsn, Worker(scanMessageFromCsn));
            var scanMessageFromAp = new AntimalwareWorker(scanner, antimalwareErrorFactory, messageStorage, apGateway);
            workerFactory.Set(Workers.ScanMessageFromAp, Worker(scanMessageFromAp));
            var scanMessageFromInstitution = new AntimalwareWorker(scanner, antimalwareErrorFactory, messageStorage, institutionGateway);
            workerFactory.Set(Workers.ScanMessageFromInstitution, Worker(scanMessageFromInstitution));

            var documentValidator = new DocumentValidator();
            var documentValidationErrorFactory = new DocumentValidationErrorFactory();
            var validateDocumentFromCsn = new DocumentValidationWorker(documentValidator, documentValidationErrorFactory, messageStorage, csnGateway);
            workerFactory.Set(Workers.ValidateDocumentFromCsn, Worker(validateDocumentFromCsn));
            var validateDocumentFromAp = new DocumentValidationWorker(documentValidator, documentValidationErrorFactory, messageStorage, apGateway);
            workerFactory.Set(Workers.ValidateDocumentFromAp, Worker(validateDocumentFromAp));
            var validateDocumentFromInstitution = new DocumentValidationWorker(documentValidator, documentValidationErrorFactory, messageStorage, institutionGateway);
            workerFactory.Set(Workers.ValidateDocumentFromInstitution, Worker(validateDocumentFromInstitution));

            var forwardToAp = new ForwardingWorker(apGateway);
            workerFactory.Set(Workers.ForwardToAp, Worker(forwardToAp));
            var forwardToInstitution = new ForwardingWorker(institutionGateway);
            workerFactory.Set(Workers.ForwardToInstitution, Worker(forwardToInstitution));

            var cdmStorage = new CdmStorage();
            var importCdm = new CdmImportWorker(new CdmImporter());
            workerFactory.Set(Workers.ImportCdm, Worker(importCdm));
            var reportCdm = new CdmReportWorker(new CdmReporter(), csnGateway);
            workerFactory.Set(Workers.ReportCdm, Worker(reportCdm));
            var provideCdm = new CdmRequestWorker(new CdmProvider(new CdmRequestParser(), cdmStorage, messageStorage, csnGateway));
            workerFactory.Set(Workers.ProvideCdm, Worker(provideCdm));
            var publishCdm = new CdmSubscriptionsWorker(new CdmPublisher(new CdmSubscriptionStorage(), cdmStorage, messageStorage, institutionGateway));
            workerFactory.Set(Workers.PublishCdm, Worker(publishCdm));

            var irStorage = new IrStorage();
            var importIr = new IrImportWorker(new IrImporter());
            workerFactory.Set(Workers.ImportIr, Worker(importIr));
            var provideIr = new IrRequestWorker(new IrProvider(new IrRequestParser(), irStorage, messageStorage, institutionGateway));
            workerFactory.Set(Workers.ProvideIr, Worker(provideIr));
            var publishIr = new IrSubscriptionsWorker(new IrPublisher(new IrSubscriptionStorage(), irStorage, messageStorage, institutionGateway));
            workerFactory.Set(Workers.PublishIr, Worker(publishIr));

            MessageServer = new MessageServer(new OwinWebServer(), handlerFactory);

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
