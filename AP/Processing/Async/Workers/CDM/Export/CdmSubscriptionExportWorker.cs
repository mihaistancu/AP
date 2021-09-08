namespace AP.Processing.Async.Workers.CDM.Export
{
    public class CdmSubscriptionExportWorker : IWorker
    {
        private readonly ICdmExportBuilder builder;
        private readonly IMessageStorage storage;

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
