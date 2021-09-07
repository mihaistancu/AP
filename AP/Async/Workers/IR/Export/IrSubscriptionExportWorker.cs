namespace AP.Async.Workers.IR.Export
{
    public class IrSubscriptionExportWorker : Worker
    {
        public override void Do(Work work)
        {
            System.Console.WriteLine("IrSubscriptionExport");

            work.Workflow.Done(work);
        }
    }
}
