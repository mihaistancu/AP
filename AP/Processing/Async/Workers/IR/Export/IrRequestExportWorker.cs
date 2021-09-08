namespace AP.Processing.Async.Workers.IR.Export
{
    public class IrRequestExportWorker : IWorker
    {
        private IIrExportBuilder builder;

        public IrRequestExportWorker(IIrExportBuilder builder)
        {
            this.builder = builder;
        }

        public virtual Message[] Handle(Message message)
        {
            builder.UseRequest(message);
            return builder.Build();
        }
    }
}
