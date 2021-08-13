namespace AP.Processing.Workers
{
    public class IrImportWorker : IWorker
    {
        public string Step => "IrImport";

        public void Process(WorkerInput input, IWorkflow workflow)
        {
            System.Console.WriteLine("IrImport");
        }
    }
}
