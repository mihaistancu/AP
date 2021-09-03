using AP.Processing.Workers;
using AP.Processing.Workers.Antimalware;

namespace AP.Processing.Workflows
{
    public class BusinessWorkflow : LinearWorkflow
    {
        public BusinessWorkflow(IStore store) : base(
            store.Get<IMessageBroker>(),
            store.Get<AntimalwareWorker>(),
            store.Get<ValidationWorker>(),
            store.Get<DeliveryWorker>(),
            store.Get<ArchivingWorker>())
        {
        }
    }
}
