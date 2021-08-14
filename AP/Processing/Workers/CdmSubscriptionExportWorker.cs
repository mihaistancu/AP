namespace AP.Processing.Workers
{
    public class CdmSubscriptionExportWorker : IWorker
    {
        public void Process(Work work, IWorkflow workflow)
        {
            System.Console.WriteLine("CdmSubscriptionExport");

            workflow.Done(work);
        }
    }
}
