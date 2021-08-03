using AP.Processing;
using AP.Receiver;

namespace AP.Tests.TestDoubles
{
    public class WorkflowSpy : Workflow
    {
        public bool DoneWasCalled { get; private set; }
        public bool StartWasCalled { get; private set; }

        public override void Done(WorkerOutput output)
        {
            DoneWasCalled = true;
        }

        public override void Start(Message message)
        {
            StartWasCalled = true;
        }

        public override WorkerInput GetFirst(Message message)
        {
            return null;
        }

        public override WorkerInput GetNext(WorkerOutput output)
        {
            return null;
        }
    }
}