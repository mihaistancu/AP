namespace AP.Processing.Workers
{
    public class IrImportWorker : IWorker
    {
        public void Process(WorkerInput input, IWorkflow workflow)
        {
            System.Console.WriteLine("IrImport");

            workflow.Done(this, new WorkerOutput());
        }
    }
}
