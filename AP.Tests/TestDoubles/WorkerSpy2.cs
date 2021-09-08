using AP.Async;

namespace AP.Tests.TestDoubles
{
    public class WorkerSpy2 : IWorker
    {
        public bool HandleWasCalled { get; private set; }

        public Message[] Handle(Message message)
        {
            HandleWasCalled = true;
            return new[] { message };
        }
    }
}
