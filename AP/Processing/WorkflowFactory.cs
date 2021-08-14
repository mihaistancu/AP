using AP.Processing.Workflows;

namespace AP.Processing
{
    public class WorkflowFactory
    {
        private readonly BusinessWorkflow business;
        private readonly CdmRequestWorkflow cdmRequest;
        private readonly CdmSyncWorkflow cdmSync;
        private readonly CdmVersionWorkflow cdmVersion;
        private readonly IrRequestWorkflow irRequest;
        private readonly IrSyncWorkflow irSync;

        public WorkflowFactory(
            BusinessWorkflow business,
            CdmRequestWorkflow cdmRequest,
            CdmSyncWorkflow cdmSync,
            CdmVersionWorkflow cdmVersion,
            IrRequestWorkflow irRequest,
            IrSyncWorkflow irSync)
        {
            this.business = business;
            this.cdmRequest = cdmRequest;
            this.cdmSync = cdmSync;
            this.cdmVersion = cdmVersion;
            this.irRequest = irRequest;
            this.irSync = irSync;
        }

        public IWorkflow Get(string sedType)
        {
            switch (sedType)
            {
                case "SYN001": return irSync;
                case "SYN002": return irRequest;
                case "SYN003": return cdmSync;
                case "SYN004": return cdmRequest;
                case "SYN005": return cdmVersion;
                default: return business;
            }
        }
    }
}
