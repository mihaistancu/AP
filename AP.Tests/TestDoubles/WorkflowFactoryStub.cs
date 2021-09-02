using AP.Processing;

namespace AP.Tests.TestDoubles
{
    public class WorkflowFactoryStub : IWorkflowFactory
    {
        public IWorkflow Workflow { get; set; }

        public IWorkflow Get(string sedType)
        {
            return Workflow;   
        }
    }
}
