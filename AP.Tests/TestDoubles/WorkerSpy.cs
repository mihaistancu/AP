using AP.Processing;

namespace AP.Tests.TestDoubles
{
    public class WorkerSpy : IWorker
    {
        public bool ProcessWasCalled { get; private set; }

        public void Process(WorkerInput input, Workflow workflow)
        {
            ProcessWasCalled = true;
        }
    }
}
