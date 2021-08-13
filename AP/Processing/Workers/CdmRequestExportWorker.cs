namespace AP.Processing.Workers
{
    public class CdmRequestExportWorker : IWorker
    {
        public void Process(WorkerInput input, IWorkflow workflow)
        {
            System.Console.WriteLine("CdmRequestExport");

            workflow.Done(this, new WorkerOutput());
        }
    }
}
