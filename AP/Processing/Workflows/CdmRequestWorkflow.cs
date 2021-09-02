using AP.Processing.Workers;

namespace AP.Processing.Workflows
{
    public class CdmRequestWorkflow : LinearWorkflow
    {
        public CdmRequestWorkflow(IStore store): base(
            store.Get<IMessageBroker>(),
            store.Get<AntimalwareWorker>(),
            store.Get<ValidationWorker>(),
            store.Get<CdmRequestExportWorker>(),
            store.Get<DeliveryWorker>(),
            store.Get<ArchivingWorker>())
        {
        }
    }
}
