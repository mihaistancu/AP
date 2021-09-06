using AP.Processing.Workflows;

namespace AP.Processing
{
    public class WorkflowFactory
    {
        private readonly IrSyncWorkflow irSync;
        private readonly IrRequestWorkflow irRequest;
        private readonly CdmSyncWorkflow cdmSync;
        private readonly CdmRequestWorkflow cdmRequest;
        private readonly CdmVersionWorkflow cdmVersion;
        private readonly BusinessWorkflow business;

        public WorkflowFactory(
            IrSyncWorkflow irSync,
            IrRequestWorkflow irRequest,
            CdmSyncWorkflow cdmSync,
            CdmRequestWorkflow cdmRequest,
            CdmVersionWorkflow cdmVersion,
            BusinessWorkflow business)
        {
            this.irSync = irSync;
            this.irRequest = irRequest;
            this.cdmSync = cdmSync;
            this.cdmRequest = cdmRequest;
            this.cdmVersion = cdmVersion;
            this.business = business;
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
