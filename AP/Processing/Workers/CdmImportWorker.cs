namespace AP.Processing.Workers
{
    public class CdmImportWorker : IWorker
    {
        public void Process(Work work, IWorkflow workflow)
        {
            System.Console.WriteLine("CdmImport");

            workflow.Done(work);
        }
    }
}
