namespace AP.Processing.Workers
{
    public class ValidationWorker : IWorker
    {
        public void Process(Work work, IWorkflow workflow)
        {
            System.Console.WriteLine("Validation");

            workflow.Done(work);
        }
    }
}
