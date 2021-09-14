using AP.Middleware.RabbitMQ.Serialization;
using AP.Antimalware.Amsi;
using System;
using Unity;
using AP.Validation;
using AP.IR;
using AP.CDM;
using AP.AS4;
using AP.Processing.Async.Workers.CDM.Import;
using AP.Processing.Async;
using AP.Monitoring.Workers;
using AP.Monitoring.Handlers;
using AP.Storage;
using AP.Cryptography;
using AP.Signing;
using AP.Certificates;
using AP.Service.WebApi;
using AP.Processing.Async.Antimalware;
using AP.Processing.Async.CDM.Export;
using AP.Processing.Async.CDM.Import;
using AP.Processing.Async.CDM.Report;
using AP.Processing.Async.DocumentValidation;
using AP.Processing.Async.IR.Import;
using AP.Processing.Sync.Decryption;
using AP.Processing.Sync.EnvelopeValidation;
using AP.Processing.Sync.Persistence;
using AP.Processing.Sync.SignatureValidation;
using AP.Processing.Sync.TlsCertificateValidation;
using AP.Processing.Async.CDM.Request;
using AP.Processing.Async.IR.Request;
using AP.Processing.Async.IR.Subscriptions;
using AP.Processing.Async.CDM.Subscriptions;
using AP.Monitoring;
using AP.Processing;
using AP.Processing.Sync.Receipt;
using AP.IR.Request;
using AP.IR.Subscriptions;
using AP.Routing;
using AP.Processing.Async.Forwarding;
using AP.CDM.Report;
using AP.Routing.Config;

namespace AP.Host.Console
{
    public class Store : IDisposable
    {
        UnityContainer container;

        public Store()
        {
            container = new UnityContainer();
            container.RegisterInstance(this);

            container.RegisterType<IMessageStorage, MessageStorage>(TypeLifetime.Singleton);
            container.RegisterType<IDecryptor, Decryptor>(TypeLifetime.Singleton);
            container.RegisterType<IEncryptor, Encryptor>(TypeLifetime.Singleton);
            container.RegisterType<IEnvelopeSignatureValidator, EnvelopeSignatureValidator>(TypeLifetime.Singleton);
            container.RegisterType<ICertificateValidator, CertificateValidator>(TypeLifetime.Singleton);

            container.RegisterType<IServerConfig, ServerConfig>(TypeLifetime.Singleton);

            container.RegisterType<IOrchestratorConfig, OrchestratorConfig>(TypeLifetime.Singleton);
            container.RegisterType<Orchestrator, MonitoringRabbitMqOrchestrator>(TypeLifetime.Singleton);
            container.RegisterType<Serializer, TypeNameSerializer>(TypeLifetime.Singleton);
            container.RegisterType<MonitoringRabbitMqOrchestrator>(TypeLifetime.Singleton);

            container.RegisterType<IReceiptFactory, As4ReceiptFactory>(TypeLifetime.Singleton);
            container.RegisterType<IEnvelopeValidationErrorFactory, As4EnvelopeValidationErrorFactory>(TypeLifetime.Singleton);
            container.RegisterType<IEnvelopeSignatureValidationErrorFactory, As4EnvelopeSignatureValidationErrorFactory>(TypeLifetime.Singleton);
            container.RegisterType<IDocumentValidationErrorFactory, As4DocumentValidationErrorFactory>(TypeLifetime.Singleton);
            container.RegisterType<ITlsCertificateValidationErrorFactory, As4TlsCertificateValidationErrorFactory>(TypeLifetime.Singleton);
            container.RegisterType<IAntimalwareErrorFactory, As4AntimalwareErrorFactory>(TypeLifetime.Singleton);
            
            container.RegisterType<IScanner, AmsiScanner>(TypeLifetime.Singleton);
            
            container.RegisterType<IDocumentValidator, DocumentValidator>(TypeLifetime.Singleton);
            container.RegisterType<IEnvelopeValidator, EnvelopeValidator>(TypeLifetime.Singleton);

            container.RegisterType<IRoutingConfig, RoutingConfig>(TypeLifetime.Singleton);
            container.RegisterType<IRouter, Router>(TypeLifetime.Singleton);

            container.RegisterType<ICsnConfig, IrStorage>(TypeLifetime.Singleton);
            container.RegisterType<IInstitutionConfig, IrStorage>(TypeLifetime.Singleton);

            container.RegisterType<IIrImporter, IrStorage>(TypeLifetime.Singleton);
            container.RegisterType<IIrPublisher, IrPublisher>(TypeLifetime.Singleton);
            container.RegisterType<IIrProvider, IrProvider>(TypeLifetime.Singleton);
            
            container.RegisterType<ICdmImporter, CdmStorage>(TypeLifetime.Singleton);
            container.RegisterType<ICdmProvider, CdmProvider>(TypeLifetime.Singleton);
            container.RegisterType<ICdmPublisher, CdmPublisher>(TypeLifetime.Singleton);
            container.RegisterType<ICdmReporter, CdmReporter>(TypeLifetime.Singleton);

            container.RegisterType<IWebClient, MonitoringWebClient>(TypeLifetime.Singleton);
            container.RegisterType<IQueue, MonitoringQueue>(TypeLifetime.Singleton);

            container.RegisterType<DecryptionHandler, MonitoringDecryptionHandler>(TypeLifetime.Singleton);
            container.RegisterType<PersistenceHandler, MonitoringPersistenceHandler>(TypeLifetime.Singleton);
            container.RegisterType<SignatureValidationHandler, MonitoringSignatureValidationHandler>(TypeLifetime.Singleton);
            container.RegisterType<TlsCertificateValidationHandler, MonitoringTlsCertificateValidationHandler>(TypeLifetime.Singleton);
            container.RegisterType<EnvelopeValidationHandler, MonitoringEnvelopeValidationHandler>(TypeLifetime.Singleton);

            container.RegisterType<AntimalwareWorker, MonitoringAntimalwareWorker>(TypeLifetime.Singleton);
            container.RegisterType<MonitoringAntimalwareWorker>(TypeLifetime.Singleton);
            container.RegisterType<CdmRequestWorker, MonitoringCdmRequestWorker>(TypeLifetime.Singleton);
            container.RegisterType<MonitoringCdmRequestWorker>(TypeLifetime.Singleton);
            container.RegisterType<CdmSubscriptionsWorker, MonitoringCdmSubscriptionsWorker>(TypeLifetime.Singleton);
            container.RegisterType<MonitoringCdmSubscriptionsWorker>(TypeLifetime.Singleton);
            container.RegisterType<CdmImportWorker, MonitoringCdmImportWorker>(TypeLifetime.Singleton);
            container.RegisterType<MonitoringCdmImportWorker>(TypeLifetime.Singleton);
            container.RegisterType<CdmReportWorker, MonitoringCdmReportWorker>(TypeLifetime.Singleton);
            container.RegisterType<MonitoringCdmReportWorker>(TypeLifetime.Singleton);
            container.RegisterType<ForwardingWorker, MonitoringForwardingWorker>(TypeLifetime.Singleton);
            container.RegisterType<MonitoringForwardingWorker>(TypeLifetime.Singleton);
            container.RegisterType<IrRequestWorker, MonitoringIrRequestWorker>(TypeLifetime.Singleton);
            container.RegisterType<MonitoringIrRequestWorker>(TypeLifetime.Singleton);
            container.RegisterType<IrSubscriptionsWorker, MonitoringIrSubscriptionsWorker>(TypeLifetime.Singleton);
            container.RegisterType<MonitoringIrSubscriptionsWorker>(TypeLifetime.Singleton);
            container.RegisterType<IrImportWorker, MonitoringIrImportWorker>(TypeLifetime.Singleton);
            container.RegisterType<MonitoringIrImportWorker>(TypeLifetime.Singleton);
            container.RegisterType<DocumentValidationWorker, MonitoringDocumentValidationWorker>(TypeLifetime.Singleton);
            container.RegisterType<MonitoringDocumentValidationWorker>(TypeLifetime.Singleton);
        }

        public T Get<T>()
        {
            return container.Resolve<T>();
        }

        public T Get<T>(Type type)
        {
            return (T)container.Resolve(type);
        }

        public void Dispose()
        {
            container.Dispose();
        }
    }
}
