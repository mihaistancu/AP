namespace AP.Tests
{
    public class MockPipeline : Pipeline
    {
        public ProcessingRequest Next { get; set; }

        public override ProcessingRequest GetNext(ProcessingRequest request)
        {
            return Next;
        }
    }
}