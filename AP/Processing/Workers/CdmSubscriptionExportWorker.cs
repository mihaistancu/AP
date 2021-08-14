namespace AP.Processing.Workers
{
    public class CdmSubscriptionExportWorker : IWorker
    {
        public void Process(Work work)
        {
            System.Console.WriteLine("CdmSubscriptionExport");

            work.Workflow.Done(work);
        }
    }
}
