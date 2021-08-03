namespace AP.Tests.TestDoubles
{
    public class WorkflowStub : Workflow
    {
        public WorkerInput Next { get; set; }

        public override WorkerInput GetNext(WorkerOutput output)
        {
            return Next;
        }
    }
}