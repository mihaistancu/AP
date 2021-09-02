using AP.Processing.Workflows;

namespace AP.Processing.RabbitMQ.Serialization.Stores
{
    public class WorkflowStore : Store<IWorkflow>
    {
        public WorkflowStore(
            BusinessWorkflow business,
            CdmRequestWorkflow cdmRequest,
            CdmSyncWorkflow cdmSync,
            CdmVersionWorkflow cdmVersion,
            IrRequestWorkflow irRequest,
            IrSyncWorkflow irSync)
            : base(business,
                  cdmRequest,
                  cdmSync,
                  cdmVersion,
                  irRequest,
                  irSync)
        {
        }
    }
}
