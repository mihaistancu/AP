namespace AP.Async.Workers.IR.Export
{
    public class IrRequestExportWorker : Worker
    {
        private IIrMessageBuilder builder;

        public IrRequestExportWorker(IIrMessageBuilder builder)
        {
            this.builder = builder;
        }

        public override void Do(Work work)
        {
            System.Console.WriteLine("IrRequestExport");

            builder.UseRequest(work.Message);
            work.Message = builder.Build();

            work.Workflow.Next(work);
        }
    }
}
