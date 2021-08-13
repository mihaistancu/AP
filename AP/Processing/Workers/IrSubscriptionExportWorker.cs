namespace AP.Processing.Workers
{
    public class IrSubscriptionExportWorker : IWorker
    {
        public void Process(WorkerInput input, IWorkflow workflow)
        {
            System.Console.WriteLine("IrSubscriptionExport");

            workflow.Done(this, new WorkerOutput());
        }
    }
}
