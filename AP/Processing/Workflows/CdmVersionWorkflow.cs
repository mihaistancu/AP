using AP.Processing.Workers;
using AP.Processing.Workers.Antimalware;

namespace AP.Processing.Workflows
{
    public class CdmVersionWorkflow : LinearWorkflow
    {
        public CdmVersionWorkflow(IStore store): base(
            store.Get<IMessageBroker>(),
            store.Get<AntimalwareWorker>(),
            store.Get<ValidationWorker>(),
            store.Get<CdmVersionReportWorker>(),
            store.Get<DeliveryWorker>())
        {
        }
    }
}
