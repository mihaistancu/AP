using AP.Processing;

namespace AP.Tests.TestDoubles
{
    public class WorkflowStub : Workflow
    {
        public WorkerInput First { get; set; }
        public WorkerInput Next { get; set; }

        public override WorkerInput GetFirst(Message message)
        {
            return First;
        }

        public override WorkerInput GetNext(WorkerOutput output)
        {
            return Next;
        }
    }
}