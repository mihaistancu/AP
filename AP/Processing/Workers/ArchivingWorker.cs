namespace AP.Processing.Workers
{
    public class ArchivingWorker : IWorker
    {
        public void Process(Work work, IWorkflow workflow)
        {
            System.Console.WriteLine("Archiving");

            workflow.Done(work);
        }
    }
}
