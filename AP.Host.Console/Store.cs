using AP.Middleware.RabbitMQ;
using AP.Middleware.RabbitMQ.Serialization;
using AP.Antimalware.Amsi;
using System;
using Unity;
using AP.Validation;
using AP.IR;
using AP.CDM;
using AP.Service.WebApi;
using AP.AS4;
using AP.Processing.Async.Workers.Antimalware;
using AP.Processing.Async.Workers.CDM.Export;
using AP.Processing.Async.Workers.CDM.Import;
using AP.Processing.Async.Workers.CDM.Report;
using AP.Processing.Async.Workers.CDM;
using AP.Processing.Async.Workers.Delivery;
using AP.Processing.Async.Workers.IR.Export;
using AP.Processing.Async.Workers.IR.Import;
using AP.Processing.Async.Workers.IR;
using AP.Processing.Async.Workers.Validation;
using AP.Processing.Async;
using AP.Processing.Sync.Handlers.Validation;
using AP.Signals;
using AP.Monitoring.Workers;
using AP.Processing.Sync.Handlers;
using AP.Monitoring.Handlers;
using AP.Processing;
using AP.Monitoring;
using AP.Storage;

namespace AP.Host.Console
{
    public class Store : IStore, IProvider, IDisposable
    {
        UnityContainer container;

        public Store()
        {
            container = new UnityContainer();
            container.RegisterInstance<IStore>(this);
            container.RegisterInstance<IProvider>(this);

            container.RegisterType<MessageBroker, RabbitMqMessageBroker>(TypeLifetime.Singleton);
            container.RegisterType<RabbitMqMessageBroker>(TypeLifetime.Singleton);

            container.RegisterType<IErrorFactory, As4ErrorFactory>(TypeLifetime.Singleton);

            container.RegisterType<IScanner, AmsiScanner>(TypeLifetime.Singleton);
            
            container.RegisterType<IDocumentValidator, DocumentValidator>(TypeLifetime.Singleton);
            container.RegisterType<IEnvelopeValidator, EnvelopeValidator>(TypeLifetime.Singleton);
            
            container.RegisterType<IRouter, Delivery.Router>(TypeLifetime.Singleton);
            
            container.RegisterType<IIrParser, IrParser>(TypeLifetime.Singleton);
            container.RegisterType<IIrStorage, IrStorage>(TypeLifetime.Singleton);
            container.RegisterType<IIrExportBuilder, IrExportBuilder>(TypeLifetime.Singleton);
            
            container.RegisterType<ICdmParser, CdmParser>(TypeLifetime.Singleton);
            container.RegisterType<ICdmStorage, CdmStorage>(TypeLifetime.Singleton);
            container.RegisterType<ICdmExportBuilder, CdmExportBuilder>(TypeLifetime.Singleton);
            container.RegisterType<ICdmReportBuilder, CdmReportBuilder>(TypeLifetime.Singleton);
            
            container.RegisterType<DecryptionHandler, MonitoringDecryptionHandler>(TypeLifetime.Singleton);
            container.RegisterType<PersistenceHandler, MonitoringPersistenceHandler>(TypeLifetime.Singleton);
            container.RegisterType<SignatureCheckHandler, MonitoringSignatureCheckHandler>(TypeLifetime.Singleton);
            container.RegisterType<TlsCheckHandler, MonitoringTlsCheckHandler>(TypeLifetime.Singleton);
            container.RegisterType<ValidationHandler, MonitoringValidationHandler>(TypeLifetime.Singleton);

            container.RegisterType<AntimalwareWorker, MonitoringAntimalwareWorker>(TypeLifetime.Singleton);
            container.RegisterType<MonitoringAntimalwareWorker>(TypeLifetime.Singleton);
            container.RegisterType<CdmRequestExportWorker, MonitoringCdmRequestExportWorker>(TypeLifetime.Singleton);
            container.RegisterType<MonitoringCdmRequestExportWorker>(TypeLifetime.Singleton);
            container.RegisterType<CdmSubscriptionExportWorker, MonitoringCdmSubscriptionExportWorker>(TypeLifetime.Singleton);
            container.RegisterType<MonitoringCdmSubscriptionExportWorker>(TypeLifetime.Singleton);
            container.RegisterType<CdmImportWorker, MonitoringCdmImportWorker>(TypeLifetime.Singleton);
            container.RegisterType<MonitoringCdmImportWorker>(TypeLifetime.Singleton);
            container.RegisterType<CdmVersionReportWorker, MonitoringCdmVersionReportWorker>(TypeLifetime.Singleton);
            container.RegisterType<MonitoringCdmVersionReportWorker>(TypeLifetime.Singleton);
            container.RegisterType<DeliveryWorker, MonitoringDeliverWorker>(TypeLifetime.Singleton);
            container.RegisterType<MonitoringDeliverWorker>(TypeLifetime.Singleton);
            container.RegisterType<IrRequestExportWorker, MonitoringIrRequestExportWorker>(TypeLifetime.Singleton);
            container.RegisterType<MonitoringIrRequestExportWorker>(TypeLifetime.Singleton);
            container.RegisterType<IrSubscriptionExportWorker, MonitoringIrSubscriptionExportWorker>(TypeLifetime.Singleton);
            container.RegisterType<MonitoringIrSubscriptionExportWorker>(TypeLifetime.Singleton);
            container.RegisterType<IrImportWorker, MonitoringIrImportWorker>(TypeLifetime.Singleton);
            container.RegisterType<MonitoringIrImportWorker>(TypeLifetime.Singleton);
            container.RegisterType<ValidationWorker, MonitoringValidationWorker>(TypeLifetime.Singleton);
            container.RegisterType<MonitoringValidationWorker>(TypeLifetime.Singleton);

            container.RegisterType<Controller, MonitoringController>();

            container.RegisterType<IMessageStorage, MessageStorage>(TypeLifetime.Singleton);
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
