namespace AP.Processing.Workers
{
    public class IrImportWorker : IWorker
    {
        public void Process(Work work)
        {
            System.Console.WriteLine("IrImport");

            work.Workflow.Done(work);
        }
    }
}
