using AP.Async;

namespace AP.Tests.TestDoubles
{
    public class WorkflowSpy : IWorkflow
    {
        public bool DoneWasCalled { get; private set; }

        public void Next(Work work)
        {
            DoneWasCalled = true;
        }

        public bool StartWasCalled { get; private set; }

        public void Start(Work work)
        {
            StartWasCalled = true;
        }
    }
}
