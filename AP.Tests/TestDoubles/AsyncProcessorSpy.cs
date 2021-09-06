namespace AP.Tests.TestDoubles
{
    public class AsyncProcessorSpy : IProcessor
    {
        public bool ProcessWasCalled { get; private set; }

        public void Process(Message message)
        {
            ProcessWasCalled = true;    
        }
    }
}
