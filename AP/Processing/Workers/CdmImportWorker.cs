namespace AP.Processing.Workers
{
    public class CdmImportWorker : IWorker
    {
        public void Process(WorkerInput input, IWorkflow workflow)
        {
            System.Console.WriteLine("CdmImport");

            workflow.Done(this, new WorkerOutput());
        }
    }
}
