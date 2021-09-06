namespace AP.Processing.Workers
{
    public class CdmRequestExportWorker : Worker
    {
        public override void Do(Work work)
        {
            System.Console.WriteLine("CdmRequestExport");

            work.Workflow.Done(work);
        }
    }
}
