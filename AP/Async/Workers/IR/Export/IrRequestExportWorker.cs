namespace AP.Async.Workers.IR.Export
{
    public class IrRequestExportWorker : Worker
    {
        public override void Do(Work work)
        {
            System.Console.WriteLine("IrRequestExport");

            work.Workflow.Done(work);
        }
    }
}
