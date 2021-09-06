using AP.Processing;

namespace AP.Tests.TestDoubles
{
    public class WorkflowSpy : IWorkflow
    {
        public bool DoneWasCalled { get; private set; }

        public void Done(Work work)
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
