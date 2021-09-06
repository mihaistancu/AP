namespace AP.Processing.Workers
{
    public class CdmImportWorker : Worker
    {
        public override void Do(Work work)
        {
            System.Console.WriteLine("CdmImport");

            work.Workflow.Done(work);
        }
    }
}
