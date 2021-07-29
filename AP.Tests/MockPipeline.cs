namespace AP.Tests
{
    public class MockPipeline: IPipeline
    {
        public bool WasCalled { get; private set; }

        public void Done(ProcessingRequest request)
        {
            WasCalled = true;
        }
    }
}