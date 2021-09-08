namespace AP.Processing.Async.Workers.IR.Export
{
    public class IrSubscriptionExportWorker : IWorker
    {
        private IIrExportBuilder builder;

        public IrSubscriptionExportWorker(IIrExportBuilder builder)
        {
            this.builder = builder;
        }

        public virtual Message[] Handle(Message message)
        {
            builder.UseSubscriptions();
            return builder.Build();
        }
    }
}
