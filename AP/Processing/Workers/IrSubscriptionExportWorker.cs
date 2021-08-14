namespace AP.Processing.Workers
{
    public class IrSubscriptionExportWorker : IWorker
    {
        public void Process(Work work)
        {
            System.Console.WriteLine("IrSubscriptionExport");

            work.Workflow.Done(work);
        }
    }
}
