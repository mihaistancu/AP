using AP.Processing.Workflows;

namespace AP.Processing
{
    public class WorkflowFactory
    {
        private readonly IStore store;

        public WorkflowFactory(IStore store)
        {
            this.store = store;
        }

        public IWorkflow Get(string sedType)
        {
            switch (sedType)
            {
                case "SYN001": return store.Get<IrSyncWorkflow>();
                case "SYN002": return store.Get<IrRequestWorkflow>();
                case "SYN003": return store.Get<CdmSyncWorkflow>();
                case "SYN004": return store.Get<CdmRequestWorkflow>();
                case "SYN005": return store.Get<CdmVersionWorkflow>();
                default: return store.Get<BusinessWorkflow>();
            }
        }
    }
}
