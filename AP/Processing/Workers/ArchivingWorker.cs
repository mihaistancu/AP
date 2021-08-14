namespace AP.Processing.Workers
{
    public class ArchivingWorker : IWorker
    {
        public void Process(Work work)
        {
            System.Console.WriteLine("Archiving");

            work.Workflow.Done(work);
        }
    }
}
