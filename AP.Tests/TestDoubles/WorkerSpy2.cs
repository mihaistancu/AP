using AP.Async;
using System.Collections.Generic;

namespace AP.Tests.TestDoubles
{
    public class WorkerSpy2 : IWorker
    {
        public bool HandleWasCalled { get; private set; }

        public IEnumerable<Message> Handle(Message message)
        {
            HandleWasCalled = true;
            yield return message;
        }
    }
}
