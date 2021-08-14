namespace AP.Processing.Workers
{
    public class IrRequestExportWorker : IWorker
    {
        public void Process(Work work, IWorkflow workflow)
        {
            System.Console.WriteLine("IrRequestExport");

            workflow.Done(work);
        }
    }
}
