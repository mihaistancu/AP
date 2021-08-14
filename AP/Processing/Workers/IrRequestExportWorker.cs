namespace AP.Processing.Workers
{
    public class IrRequestExportWorker : IWorker
    {
        public void Process(Work work)
        {
            System.Console.WriteLine("IrRequestExport");

            work.Workflow.Done(work);
        }
    }
}
