using AP.Processing.Workflows;

namespace AP.Processing.RabbitMQ.Serialization.Maps
{
    public class WorkflowMap : Map<IWorkflow>
    {
        public WorkflowMap(IStore store): base(
            store.Get<BusinessWorkflow>(),
            store.Get<CdmRequestWorkflow>(),
            store.Get<CdmSyncWorkflow>(),
            store.Get<CdmVersionWorkflow>(),
            store.Get<IrRequestWorkflow>(),
            store.Get<IrSyncWorkflow>())
        {
        }
    }
}
