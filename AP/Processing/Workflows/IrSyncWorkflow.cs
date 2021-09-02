using AP.Processing.Workers;

namespace AP.Processing.Workflows
{
    public class IrSyncWorkflow : LinearWorkflow
    {
        public IrSyncWorkflow(IStore store): base(
            store.Get<IMessageBroker>(),
            store.Get<AntimalwareWorker>(),
            store.Get<ValidationWorker>(),
            store.Get<IrImportWorker>(),
            store.Get<IrSubscriptionExportWorker>(),
            store.Get<DeliveryWorker>(),
            store.Get<ArchivingWorker>())
        {
        }
    }
}
