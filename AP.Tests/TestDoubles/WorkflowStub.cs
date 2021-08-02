namespace AP.Tests.TestDoubles
{
    public class WorkflowStub : Workflow
    {
        public ProcessingRequest Next { get; set; }

        public override ProcessingRequest GetNext(ProcessingRequest request)
        {
            return Next;
        }
    }
}