namespace AP.Processing.Workers
{
    public class IrImportWorker : IWorker
    {
        public void Process(Work work, IWorkflow workflow)
        {
            System.Console.WriteLine("IrImport");

            workflow.Done(work);
        }
    }
}
