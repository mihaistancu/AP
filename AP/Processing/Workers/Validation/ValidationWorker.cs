namespace AP.Processing.Workers.Validation
{
    public class ValidationWorker : Worker
    {
        public override void Do(Work work)
        {
            System.Console.WriteLine("Validation");

            work.Workflow.Done(work);
        }
    }
}
