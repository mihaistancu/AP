using AP.Data;

namespace AP.Processing.Async.Workers.IR.Export
{
    public class IrSubscriptionExportWorker : IWorker
    {
        private IIrExportBuilder builder;
        private readonly IMessageStorage storage;

        public IrSubscriptionExportWorker(
            IIrExportBuilder builder,
            IMessageStorage storage)
        {
            this.builder = builder;
            this.storage = storage;
        }

        public virtual Message[] Handle(Message message)
        {
            builder.UseSubscriptions();
            var messages = builder.Build();
            storage.Save(messages);
            return messages;
        }
    }
}
