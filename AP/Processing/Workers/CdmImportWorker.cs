namespace AP.Processing.Workers
{
    public class CdmImportWorker : IWorker
    {
        public void Process(Work work)
        {
            System.Console.WriteLine("CdmImport");

            work.Workflow.Done(work);
        }
    }
}
