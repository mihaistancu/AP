using AP.Processing.Workers;

namespace AP.Processing.Workflows
{
    public class CdmSyncWorkflow : LinearWorkflow
    {
        public CdmSyncWorkflow(IStore store): base(
            store.Get<IMessageBroker>(),
            store.Get<AntimalwareWorker>(),
            store.Get<ValidationWorker>(),
            store.Get<CdmImportWorker>(),
            store.Get<CdmSubscriptionExportWorker>(),
            store.Get<DeliveryWorker>(),
            store.Get<ArchivingWorker>())
        {
        }
    }
}
