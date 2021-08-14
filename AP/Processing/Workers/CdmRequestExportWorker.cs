namespace AP.Processing.Workers
{
    public class CdmRequestExportWorker : IWorker
    {
        public void Process(Work work)
        {
            System.Console.WriteLine("CdmRequestExport");

            work.Workflow.Done(work);
        }
    }
}
