namespace AP.Processing.Workers
{
    public class CdmSubscriptionExportWorker : Worker
    {
        public override void Do(Work work)
        {
            System.Console.WriteLine("CdmSubscriptionExport");

            work.Workflow.Done(work);
        }
    }
}
