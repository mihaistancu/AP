namespace AP.Processing.Workers
{
    public class CdmRequestExportWorker : IWorker
    {
        public void Process(Work work, IWorkflow workflow)
        {
            System.Console.WriteLine("CdmRequestExport");

            workflow.Done(work);
        }
    }
}
