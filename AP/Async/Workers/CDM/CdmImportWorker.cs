namespace AP.Async.Workers.CDM
{
    public class CdmImportWorker : Worker
    {
        public override void Do(Work work)
        {
            System.Console.WriteLine("CdmImport");

            work.Workflow.Next(work);
        }
    }
}
