namespace AP.Processing.Workers
{
    public class ValidationWorker : IWorker
    {
        public void Process(Work work)
        {
            System.Console.WriteLine("Validation");

            work.Workflow.Done(work);
        }
    }
}
