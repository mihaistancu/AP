using AP.Processing.Workers;

namespace AP.Processing.RabbitMQ.Serialization.Maps
{
    public class WorkerMap : Map<IWorker>
    {
        public WorkerMap(IStore store): base(
            store.Get<AntimalwareWorker>(),
            store.Get<ArchivingWorker>(),
            store.Get<CdmImportWorker>(),
            store.Get<CdmRequestExportWorker>(),
            store.Get<CdmSubscriptionExportWorker>(),
            store.Get<CdmVersionReportWorker>(),
            store.Get<DeliveryWorker>(),
            store.Get<IrImportWorker>(),
            store.Get<IrRequestExportWorker>(),
            store.Get<IrSubscriptionExportWorker>(),
            store.Get<ValidationWorker>())
        {
        }
    }
}
