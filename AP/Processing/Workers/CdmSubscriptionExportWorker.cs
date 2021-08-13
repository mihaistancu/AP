namespace AP.Processing.Workers
{
    public class CdmSubscriptionExportWorker : IWorker
    {
        public string Step => "CdmSubscriptionExport";

        public void Process(WorkerInput input, IWorkflow workflow)
        {
            System.Console.WriteLine("CdmSubscriptionExport");
        }
    }
}
