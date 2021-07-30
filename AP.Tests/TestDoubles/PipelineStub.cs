namespace AP.Tests.TestDoubles
{
    public class PipelineStub : Pipeline
    {
        public ProcessingRequest Next { get; set; }

        public override ProcessingRequest GetNext(ProcessingRequest request)
        {
            return Next;
        }
    }
}