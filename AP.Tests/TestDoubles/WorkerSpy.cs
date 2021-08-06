using AP.Processing;

namespace AP.Tests.TestDoubles
{
    public class WorkerSpy : IWorker
    {
        public bool ProcessWasCalled { get; private set; }

        public string Step { get; set; }

        public void Process(WorkerInput input, IWorkflow workflow)
        {
            ProcessWasCalled = true;
        }
    }
}
