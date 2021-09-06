using AP.Processing;

namespace AP.Tests.TestDoubles
{
    public class AsyncProcessorSpy : IAsyncProcessor
    {
        public bool ProcessWasCalled { get; private set; }

        public void Process(Message message)
        {
            ProcessWasCalled = true;    
        }
    }
}
