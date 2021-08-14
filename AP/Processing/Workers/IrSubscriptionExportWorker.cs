namespace AP.Processing.Workers
{
    public class IrSubscriptionExportWorker : IWorker
    {
        public void Process(Work work, IWorkflow workflow)
        {
            System.Console.WriteLine("IrSubscriptionExport");

            workflow.Done(work);
        }
    }
}
