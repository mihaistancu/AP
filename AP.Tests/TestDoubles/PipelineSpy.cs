namespace AP.Tests.TestDoubles
{
    public class PipelineSpy : Pipeline
    {
        public bool WasCalled { get; private set; }

        public override void Done(ProcessingRequest request)
        {
            WasCalled = true;
        }

        public override ProcessingRequest GetNext(ProcessingRequest request)
        {
            return request;
        }
    }
}