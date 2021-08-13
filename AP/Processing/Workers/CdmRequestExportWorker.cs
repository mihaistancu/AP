namespace AP.Processing.Workers
{
    public class CdmRequestExportWorker : IWorker
    {
        public string Step => "CdmRequestExport";

        public void Process(WorkerInput input, IWorkflow workflow)
        {
            System.Console.WriteLine("CdmRequestExport");
        }
    }
}
