namespace AP.Processing.Workers
{
    public class CdmVersionReportWorker : IWorker
    {
        public void Process(Work work)
        {
            System.Console.WriteLine("CdmVersion");

            work.Workflow.Done(work);
        }
    }
}
