using AP.Data;

namespace AP.Processing.Async.Workers.CDM.Export
{
    public class CdmSubscriptionExportWorker : IWorker
    {
        private ICdmExportBuilder builder;
        private IMessageStorage storage;

        public CdmSubscriptionExportWorker(
            ICdmExportBuilder builder, 
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
