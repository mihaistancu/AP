using AP.Processing;

namespace AP.Tests.TestDoubles
{
    public class WorkerSpy2 : IWorker
    {
        public bool ProcessWasCalled { get; private set; }

        public string Step { get; set; }

        public void Process(Work work)
        {
            ProcessWasCalled = true;
        }
    }
}
