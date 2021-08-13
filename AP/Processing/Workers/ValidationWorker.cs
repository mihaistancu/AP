namespace AP.Processing.Workers
{
    public class ValidationWorker : IWorker
    {
        public string Step => "Validation";

        public void Process(WorkerInput input, IWorkflow workflow)
        {
            System.Console.WriteLine("Validation");

            workflow.Done(this, new WorkerOutput());
        }
    }
}
