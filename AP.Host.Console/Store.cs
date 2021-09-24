using AP.Gateways.AP;
using AP.Gateways.CSN;
using AP.Gateways.Institution;
using AP.Messaging.Client;
using AP.Messaging.Queue;
using AP.Messaging.Service;
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
using Unity;
using Unity.RegistrationByConvention;

namespace AP.Host.Console
{
    public class Store
    {
        private UnityContainer container = new UnityContainer();
        private HandlerFactory handlerFactory = new HandlerFactory();
        private WorkerFactory workerFactory = new WorkerFactory();

        private IHandler ProcessAsync => container.Resolve<AsyncProcessingHandler>();
        private IHandler Decrypt => container.Resolve<DecryptionHandler>();
        private IHandler ValidateEnvelope => container.Resolve<EnvelopeValidationHandler>();
        private IHandler Persist => container.Resolve<PersistenceHandler>();
        private IHandler PullRequest => container.Resolve<PullRequestHandler>();
        private IHandler Receipt => container.Resolve<ReceiptHandler>();
        private IHandler ValidateSignature => container.Resolve<SignatureValidationHandler>();
        private IHandler ValidateTlsCertificate => container.Resolve<TlsCertificateValidationHandler>();

        private IWorker ScanMessageFromCsn => container.Resolve<AntimalwareWorker<CsnGateway>>();
        private IWorker ScanMessageFromAp => container.Resolve<AntimalwareWorker<ApGateway>>();
        private IWorker ScanMessageFromInstitution => container.Resolve<AntimalwareWorker<InstitutionGateway>>();
        private IWorker ValidateDocumentFromCsn => container.Resolve<DocumentValidationWorker<CsnGateway>>();
        private IWorker ValidateDocumentFromAp => container.Resolve<DocumentValidationWorker<ApGateway>>();
        private IWorker ValidateDocumentFromInstitution => container.Resolve<DocumentValidationWorker<InstitutionGateway>>();
        private IWorker ForwardToAp => container.Resolve<ForwardingWorker<ApGateway>>();
        private IWorker ForwardToInstitution => container.Resolve<ForwardingWorker<InstitutionGateway>>();
        private IWorker ImportCdm => container.Resolve<CdmImportWorker>();
        private IWorker ReportCdm => container.Resolve<CdmReportWorker<CsnGateway>>();
        private IWorker ProvideCdm => container.Resolve<CdmRequestWorker>();
        private IWorker PublishCdm => container.Resolve<CdmSubscriptionsWorker>();
        private IWorker ImportIr => container.Resolve<IrImportWorker>();
        private IWorker ProvideIr => container.Resolve<IrRequestWorker>();
        private IWorker PublishIr => container.Resolve<IrSubscriptionsWorker>();

        private IMessageClient MessageClient => container.Resolve<MessageClient>();
        private IMessageQueue MessageQueue => container.Resolve<MessageQueue>();

        public void RegisterDependencies()
        {
            container.RegisterTypes(
                AllClasses.FromAssembliesInBasePath(),
                WithMappings.FromMatchingInterface,
                WithName.Default);

            container.RegisterType<RoutingRuleStorage>(TypeLifetime.Singleton);
            container.RegisterType<Orchestrator>(TypeLifetime.Singleton);

            container.RegisterInstance(handlerFactory);
            container.RegisterInstance(workerFactory);
        }

        public void EnableMonitoring()
        {
            Register(Handlers.ProcessAsync, new MonitoredHandler(ProcessAsync));
            Register(Handlers.Decrypt, new MonitoredHandler(Decrypt));
            Register(Handlers.ValidateEnvelope, new MonitoredHandler(ValidateEnvelope));
            Register(Handlers.Persist, new MonitoredHandler(Persist));
            Register(Handlers.PullRequest, new MonitoredHandler(PullRequest));
            Register(Handlers.Receipt, new MonitoredHandler(Receipt));
            Register(Handlers.ValidateSignature, new MonitoredHandler(ValidateSignature));
            Register(Handlers.ValidateTlsCertificate, new MonitoredHandler(ValidateTlsCertificate));

            Register(Workers.ScanMessageFromCsn, new MonitoredWorker(ScanMessageFromCsn));
            Register(Workers.ScanMessageFromAp, new MonitoredWorker(ScanMessageFromAp));
            Register(Workers.ScanMessageFromInstitution, new MonitoredWorker(ScanMessageFromInstitution));
            Register(Workers.ValidateDocumentFromCsn, new MonitoredWorker(ValidateDocumentFromCsn));
            Register(Workers.ValidateDocumentFromAp, new MonitoredWorker(ValidateDocumentFromAp));
            Register(Workers.ValidateDocumentFromInstitution, new MonitoredWorker(ValidateDocumentFromInstitution));
            Register(Workers.ForwardToAp, new MonitoredWorker(ForwardToAp));
            Register(Workers.ForwardToInstitution, new MonitoredWorker(ForwardToInstitution));
            Register(Workers.ImportCdm, new MonitoredWorker(ImportCdm));
            Register(Workers.ReportCdm, new MonitoredWorker(ReportCdm));
            Register(Workers.ProvideCdm, new MonitoredWorker(ProvideCdm));
            Register(Workers.PublishCdm, new MonitoredWorker(PublishCdm));
            Register(Workers.ImportIr, new MonitoredWorker(ImportIr));
            Register(Workers.ProvideIr, new MonitoredWorker(ProvideIr));
            Register(Workers.PublishIr, new MonitoredWorker(PublishIr));

            container.RegisterInstance<IMessageClient>(new MonitoredMessageClient(MessageClient));
            container.RegisterInstance<IMessageQueue>(new MonitoredMessageQueue(MessageQueue));
        }

        public void DisableMonitoring()
        {
            Register(Handlers.ProcessAsync, ProcessAsync);
            Register(Handlers.Decrypt, Decrypt);
            Register(Handlers.ValidateEnvelope, ValidateEnvelope);
            Register(Handlers.Persist, Persist);
            Register(Handlers.PullRequest, PullRequest);
            Register(Handlers.Receipt, Receipt);
            Register(Handlers.ValidateSignature, ValidateSignature);
            Register(Handlers.ValidateTlsCertificate, ValidateTlsCertificate);

            Register(Workers.ScanMessageFromCsn, ScanMessageFromCsn);
            Register(Workers.ScanMessageFromAp, ScanMessageFromAp);
            Register(Workers.ScanMessageFromInstitution, ScanMessageFromInstitution);
            Register(Workers.ValidateDocumentFromCsn, ValidateDocumentFromCsn);
            Register(Workers.ValidateDocumentFromAp, ValidateDocumentFromAp);
            Register(Workers.ValidateDocumentFromInstitution, ValidateDocumentFromInstitution);
            Register(Workers.ForwardToAp, ForwardToAp);
            Register(Workers.ForwardToInstitution, ForwardToInstitution);
            Register(Workers.ImportCdm, ImportCdm);
            Register(Workers.ReportCdm, ReportCdm);
            Register(Workers.ProvideCdm, ProvideCdm);
            Register(Workers.PublishCdm, PublishCdm);
            Register(Workers.ImportIr, ImportIr);
            Register(Workers.ProvideIr, ProvideIr);
            Register(Workers.PublishIr, PublishIr);

            container.RegisterInstance(MessageClient);
            container.RegisterInstance(MessageQueue);
        }

        private void Register(string name, IHandler handler)
        {
            container.RegisterInstance(name, handler);
            handlerFactory.Set(name, handler);
        }

        private void Register(string name, IWorker worker)
        {
            container.RegisterInstance(name, worker);
            workerFactory.Set(name, worker);
        }

        public T Get<T>()
        {
            return container.Resolve<T>();
        }
    }
}
