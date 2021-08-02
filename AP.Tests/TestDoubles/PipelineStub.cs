namespace AP.Tests.TestDoubles
{
    public class PipelineStub : Workflow
    {
        public ProcessingRequest Next { get; set; }

        public override ProcessingRequest GetNext(ProcessingRequest request)
        {
            return Next;
        }
    }
}