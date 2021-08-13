namespace AP.Processing.Workers
{
    public class CdmSubscriptionExportWorker : IWorker
    {
        public void Process(WorkerInput input, IWorkflow workflow)
        {
            System.Console.WriteLine("CdmSubscriptionExport");

            workflow.Done(this, new WorkerOutput());
        }
    }
}
