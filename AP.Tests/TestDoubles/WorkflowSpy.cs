using AP.Processing;

namespace AP.Tests.TestDoubles
{
    public class WorkflowSpy : Workflow
    {
        public bool WasCalled { get; private set; }

        public override void Done(WorkerOutput output)
        {
            WasCalled = true;
        }

        public override WorkerInput GetNext(WorkerOutput output)
        {
            return null;
        }
    }
}