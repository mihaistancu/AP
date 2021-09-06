namespace AP.Processing.Workers
{
    public class ArchivingWorker : Worker
    {
        public override void Do(Work work)
        {
            System.Console.WriteLine("Archiving");

            work.Workflow.Done(work);
        }
    }
}
