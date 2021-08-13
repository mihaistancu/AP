namespace AP.Processing.Workers
{
    public class IrRequestExportWorker : IWorker
    {
        public void Process(WorkerInput input, IWorkflow workflow)
        {
            System.Console.WriteLine("IrRequestExport");

            workflow.Done(this, new WorkerOutput());
        }
    }
}
