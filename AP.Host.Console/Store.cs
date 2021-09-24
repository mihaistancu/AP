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
    public class Store
    {
        private HandlerFactory handlerFactory;
        private WorkerFactory workerFactory;
        private MessageStorage messageStorage;
        private Orchestrator orchestrator;
        private MessageServer messageServer;
        private ConfigurationServer configurationServer;
        
        public void RegisterDependencies()
        {
            handlerFactory = new HandlerFactory();
            workerFactory = new WorkerFactory();
            messageStorage = new MessageStorage();
            
            orchestrator = new Orchestrator(new OrchestratorConfig(), messageStorage, new MessageBroker(new Broker()), workerFactory);

            var messageClient = new MessageClient();
            var messageQueue = new MessageQueue();

            var csnGateway = new CsnGateway(new CsnConfig(), messageClient);
            var apGateway = new ApGateway(new Encryptor(), new ApConfig(), messageClient);
            var institutionGateway = new InstitutionGateway(new RoutingConfig(), messageClient, messageQueue);

            var processAsync = new AsyncProcessingHandler(orchestrator);
            handlerFactory.Set(Handlers.ProcessAsync, processAsync);
            
            var decrypt = new DecryptionHandler(new Decryptor());
            handlerFactory.Set(Handlers.Decrypt, decrypt);
            
            var validateEnvelope = new EnvelopeValidationHandler(new EnvelopeValidator(), new EnvelopeValidationErrorFactory());
            handlerFactory.Set(Handlers.ValidateEnvelope, validateEnvelope);
            
            var persist = new PersistenceHandler(messageStorage);
            handlerFactory.Set(Handlers.Persist, persist);
            
            var pullRequest = new PullRequestHandler(new MessageProvider(messageQueue));
            handlerFactory.Set(Handlers.PullRequest, pullRequest);
            
            var receipt = new ReceiptHandler(new ReceiptFactory());
            handlerFactory.Set(Handlers.Receipt, receipt);
            
            var validateSignature = new SignatureValidationHandler(new EnvelopeSignatureValidator(), new EnvelopeSignatureValidationErrorFactory());
            handlerFactory.Set(Handlers.ValidateSignature, validateSignature);
            
            var validateTlsCertificate = new TlsCertificateValidationHandler(new CertificateValidator(), new TlsCertificateValidationErrorFactory());
            handlerFactory.Set(Handlers.ValidateTlsCertificate, validateTlsCertificate);

            var scanner = new Scanner();
            var antimalwareErrorFactory = new AntimalwareErrorFactory();
            var scanMessageFromCsn = new AntimalwareWorker(scanner, antimalwareErrorFactory, messageStorage, csnGateway);
            workerFactory.Set(Workers.ScanMessageFromCsn, scanMessageFromCsn);
            var scanMessageFromAp = new AntimalwareWorker(scanner, antimalwareErrorFactory, messageStorage, apGateway);
            workerFactory.Set(Workers.ScanMessageFromAp, scanMessageFromAp);
            var scanMessageFromInstitution = new AntimalwareWorker(scanner, antimalwareErrorFactory, messageStorage, institutionGateway);
            workerFactory.Set(Workers.ScanMessageFromInstitution, scanMessageFromInstitution);

            var documentValidator = new DocumentValidator();
            var documentValidationErrorFactory = new DocumentValidationErrorFactory();
            var validateDocumentFromCsn = new DocumentValidationWorker(documentValidator, documentValidationErrorFactory, messageStorage, csnGateway);
            workerFactory.Set(Workers.ValidateDocumentFromCsn, validateDocumentFromCsn);
            var validateDocumentFromAp = new DocumentValidationWorker(documentValidator, documentValidationErrorFactory, messageStorage, apGateway);
            workerFactory.Set(Workers.ValidateDocumentFromAp, validateDocumentFromAp);
            var validateDocumentFromInstitution = new DocumentValidationWorker(documentValidator, documentValidationErrorFactory, messageStorage, institutionGateway);
            workerFactory.Set(Workers.ValidateDocumentFromInstitution, validateDocumentFromInstitution);

            var forwardToAp = new ForwardingWorker(apGateway);
            workerFactory.Set(Workers.ForwardToAp, forwardToAp);
            var forwardToInstitution = new ForwardingWorker(institutionGateway);
            workerFactory.Set(Workers.ForwardToInstitution, forwardToInstitution);

            var cdmStorage = new CdmStorage();
            var importCdm = new CdmImportWorker(new CdmImporter());
            workerFactory.Set(Workers.ImportCdm, importCdm);
            var reportCdm = new CdmReportWorker(new CdmReporter(), csnGateway);
            workerFactory.Set(Workers.ReportCdm, reportCdm);
            var provideCdm = new CdmRequestWorker(new CdmProvider(new CdmRequestParser(), cdmStorage, messageStorage, csnGateway));
            workerFactory.Set(Workers.ProvideCdm, provideCdm);
            var publishCdm = new CdmSubscriptionsWorker(new CdmPublisher(new CdmSubscriptionStorage(), cdmStorage, messageStorage, institutionGateway));
            workerFactory.Set(Workers.PublishCdm, publishCdm);

            var irStorage = new IrStorage();
            var importIr = new IrImportWorker(new IrImporter());
            workerFactory.Set(Workers.ImportIr, importIr);
            var provideIr = new IrRequestWorker(new IrProvider(new IrRequestParser(), irStorage, messageStorage, institutionGateway));
            workerFactory.Set(Workers.ProvideIr, provideIr);
            var publishIr = new IrSubscriptionsWorker(new IrPublisher(new IrSubscriptionStorage(), irStorage, messageStorage, institutionGateway));
            workerFactory.Set(Workers.PublishIr, publishIr);

            messageServer = new MessageServer(new WebServer(), handlerFactory);

            var routingRuleStorage = new RoutingRuleStorage();
            configurationServer = new ConfigurationServer(
                new WebServer(), 
                new GetAllRoutingRulesApi(routingRuleStorage),
                new AddRoutingRuleApi(routingRuleStorage),
                new UpdateRoutingRuleApi(routingRuleStorage),
                new DeleteRoutingRuleApi(routingRuleStorage));
        }

        public Orchestrator GetOrchestrator()
        {
            return orchestrator;
        }

        public MessageServer GetMessageServer()
        {
            return messageServer;
        }

        public ConfigurationServer GetConfigurationServer()
        {
            return configurationServer;
        }
    }
}
