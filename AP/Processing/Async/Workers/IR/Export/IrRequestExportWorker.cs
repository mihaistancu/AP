using AP.Data;

namespace AP.Processing.Async.Workers.IR.Export
{
    public class IrRequestExportWorker : IWorker
    {
        private IIrExportBuilder builder;
        private IMessageStorage storage;

        public IrRequestExportWorker(
            IIrExportBuilder builder,
            IMessageStorage storage)
        {
            this.builder = builder;
            this.storage = storage;
        }

        public virtual Message[] Handle(Message message)
        {
            builder.UseRequest(message);
            var messages = builder.Build();
            storage.Save(messages);
            return messages;
        }
    }
}
