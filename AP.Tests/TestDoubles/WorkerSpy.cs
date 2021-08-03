namespace AP.Tests.TestDoubles
{
    public class WorkerSpy : IWorker
    {
        public bool WasCalled { get; private set; }

        public WorkerOutput Process(WorkerInput input)
        {
            WasCalled = true;
            return null;
        }
    }
}
