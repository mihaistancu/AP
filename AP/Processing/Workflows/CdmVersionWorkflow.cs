using AP.Processing.Workers;

namespace AP.Processing.Workflows
{
    public class CdmVersionWorkflow : LinearWorkflow
    {
        public CdmVersionWorkflow(IStore store): base(
            store.Get<IMessageBroker>(),
            store.Get<AntimalwareWorker>(),
            store.Get<ValidationWorker>(),
            store.Get<CdmVersionReportWorker>(),
            store.Get<DeliveryWorker>(),
            store.Get<ArchivingWorker>())
        {
        }
    }
}
