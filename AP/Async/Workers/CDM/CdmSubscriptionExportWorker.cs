namespace AP.Async.Workers.CDM
{
    public class CdmSubscriptionExportWorker : Worker
    {
        public override void Do(Work work)
        {
            System.Console.WriteLine("CdmSubscriptionExport");

            work.Workflow.Next(work);
        }
    }
}
