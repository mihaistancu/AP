using AP.Processing;

namespace AP.Tests.TestDoubles
{
    public class WorkerSpy : IWorker
    {
        public bool ProcessWasCalled { get; private set; }

        public WorkerOutput Process(WorkerInput input)
        {
            ProcessWasCalled = true;
            return null;
        }
    }
}
