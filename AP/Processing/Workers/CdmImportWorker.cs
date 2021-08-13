namespace AP.Processing.Workers
{
    public class CdmImportWorker : IWorker
    {
        public string Step => "CdmImport";

        public void Process(WorkerInput input, IWorkflow workflow)
        {
            System.Console.WriteLine("CdmImport");

            workflow.Done(this, new WorkerOutput());
        }
    }
}
