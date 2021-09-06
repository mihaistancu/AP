namespace AP.Processing.Workers.IR
{
    public class IrImportWorker : Worker
    {
        public override void Do(Work work)
        {
            System.Console.WriteLine("IrImport");

            work.Workflow.Done(work);
        }
    }
}
