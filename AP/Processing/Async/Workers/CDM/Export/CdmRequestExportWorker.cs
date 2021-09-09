using AP.Data;

namespace AP.Processing.Async.Workers.CDM.Export
{
    public class CdmRequestExportWorker : IWorker
    {
        private readonly ICdmExportBuilder builder;
        private readonly IMessageStorage storage;

        public CdmRequestExportWorker(ICdmExportBuilder builder)
        {
            this.builder = builder;
        }

        public CdmRequestExportWorker(
            ICdmExportBuilder builder, 
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
