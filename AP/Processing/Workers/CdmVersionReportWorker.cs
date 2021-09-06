namespace AP.Processing.Workers
{
    public class CdmVersionReportWorker : Worker
    {
        public override void Do(Work work)
        {
            System.Console.WriteLine("CdmVersion");

            work.Workflow.Done(work);
        }
    }
}
