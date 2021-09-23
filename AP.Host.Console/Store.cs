using AP.Antimalware.Amsi;
using System;
using Unity;
using AP.Validation;
using AP.IR;
using AP.CDM;
using AP.AS4;
using AP.Processing.Async;
using AP.Storage;
using AP.Cryptography;
using AP.Signing;
using AP.Certificates;
using AP.Processing.Async.Antimalware;
using AP.Processing.Async.DocumentValidation;
using AP.Processing.Sync.Decryption;
using AP.Processing.Sync.EnvelopeValidation;
using AP.Processing.Sync.SignatureValidation;
using AP.Processing.Sync.TlsCertificateValidation;
using AP.Monitoring;
using AP.Processing;
using AP.Processing.Sync.Receipt;
using AP.IR.Request;
using AP.IR.Subscriptions;
using AP.Routing;
using AP.Gateways.Institution;
using AP.Gateways.AP;
using AP.Gateways.CSN;
using AP.Processing.Async.Synchronization.CDM.Import;
using AP.Processing.Async.Synchronization.CDM.Report;
using AP.Processing.Async.Synchronization.CDM.Request;
using AP.Processing.Async.Synchronization.CDM.Subscriptions;
using AP.Processing.Async.Synchronization.IR.Import;
using AP.Processing.Async.Synchronization.IR.Request;
using AP.Processing.Async.Synchronization.IR.Subscriptions;
using AP.Processing.Sync.PullRequest;
using AP.Messaging.Queue;
using AP.Web.Server;
using AP.Web.Server.Owin;
using AP.Middleware.RabbitMQ;

namespace AP.Host.Console
{
    public class Store : IDisposable
    {
        UnityContainer container;

        public Store()
        {
            container = new UnityContainer();
            container.RegisterInstance(this);

            container.RegisterType<IWebServer, OwinWebServer>();
            container.RegisterType<IBroker, RabbitMqBroker>();

            container.RegisterType<Workers, Workers>(TypeLifetime.Singleton);
            container.RegisterType<IWorkers, Workers>(TypeLifetime.Singleton);

            container.RegisterType<IMessageStorage, MessageStorage>(TypeLifetime.Singleton);
            container.RegisterType<IDecryptor, Decryptor>(TypeLifetime.Singleton);
            container.RegisterType<IEncryptor, Encryptor>(TypeLifetime.Singleton);
            container.RegisterType<IEnvelopeSignatureValidator, EnvelopeSignatureValidator>(TypeLifetime.Singleton);
            container.RegisterType<ICertificateValidator, CertificateValidator>(TypeLifetime.Singleton);

            container.RegisterType<Orchestrator, Orchestrator>(TypeLifetime.Singleton);

            container.RegisterType<IMessageProvider, MessageProvider>(TypeLifetime.Singleton);

            container.RegisterType<IReceiptFactory, As4ReceiptFactory>(TypeLifetime.Singleton);
            container.RegisterType<IEnvelopeValidationErrorFactory, As4EnvelopeValidationErrorFactory>(TypeLifetime.Singleton);
            container.RegisterType<IEnvelopeSignatureValidationErrorFactory, As4EnvelopeSignatureValidationErrorFactory>(TypeLifetime.Singleton);
            container.RegisterType<IDocumentValidationErrorFactory, As4DocumentValidationErrorFactory>(TypeLifetime.Singleton);
            container.RegisterType<ITlsCertificateValidationErrorFactory, As4TlsCertificateValidationErrorFactory>(TypeLifetime.Singleton);
            container.RegisterType<IAntimalwareErrorFactory, As4AntimalwareErrorFactory>(TypeLifetime.Singleton);
            
            container.RegisterType<IScanner, AmsiScanner>(TypeLifetime.Singleton);
            
            container.RegisterType<IDocumentValidator, DocumentValidator>(TypeLifetime.Singleton);
            container.RegisterType<IEnvelopeValidator, EnvelopeValidator>(TypeLifetime.Singleton);

            container.RegisterType<RoutingRuleStorage>(TypeLifetime.Singleton);
            container.RegisterType<IRoutingConfig, RoutingConfig>(TypeLifetime.Singleton);
            
            container.RegisterType<ICsnConfig, IrStorage>(TypeLifetime.Singleton);
            container.RegisterType<IApConfig, IrStorage>(TypeLifetime.Singleton);

            container.RegisterType<IIrImporter, IrStorage>(TypeLifetime.Singleton);
            container.RegisterType<IIrPublisher, IrPublisher<InstitutionGateway>>(TypeLifetime.Singleton);
            container.RegisterType<IIrProvider, IrProvider<InstitutionGateway>>(TypeLifetime.Singleton);
            
            container.RegisterType<ICdmImporter, CdmStorage>(TypeLifetime.Singleton);
            container.RegisterType<ICdmProvider, CdmProvider<InstitutionGateway>>(TypeLifetime.Singleton);
            container.RegisterType<ICdmPublisher, CdmPublisher<InstitutionGateway>>(TypeLifetime.Singleton);
            container.RegisterType<ICdmReporter, CdmStorage>(TypeLifetime.Singleton);

            container.RegisterType<IMessageClient, MonitoredMessageClient>(TypeLifetime.Singleton);
            container.RegisterType<IMessageQueue, MonitoredMessageQueue>(TypeLifetime.Singleton);
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
