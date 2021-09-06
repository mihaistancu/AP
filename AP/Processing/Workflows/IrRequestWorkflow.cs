using AP.Processing.Workers;
using AP.Processing.Workers.Antimalware;

namespace AP.Processing.Workflows
{
    public class IrRequestWorkflow : LinearWorkflow
    {
        public IrRequestWorkflow(IStore store): base(
            store.Get<IMessageBroker>(),
            store.Get<AntimalwareWorker>(),
            store.Get<ValidationWorker>(),
            store.Get<IrRequestExportWorker>(),
            store.Get<DeliveryWorker>())
        {
        }
    }
}
