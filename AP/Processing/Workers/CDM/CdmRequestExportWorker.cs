namespace AP.Processing.Workers.CDM
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
