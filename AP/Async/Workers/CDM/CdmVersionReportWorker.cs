namespace AP.Async.Workers.CDM
{
    public class CdmVersionReportWorker : Worker
    {
        public override void Do(Work work)
        {
            System.Console.WriteLine("CdmVersion");

            work.Workflow.Next(work);
        }
    }
}
