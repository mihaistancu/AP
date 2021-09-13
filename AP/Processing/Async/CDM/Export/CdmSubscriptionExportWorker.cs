using AP.Data;

namespace AP.Processing.Async.CDM.Export
{
    public class CdmSubscriptionExportWorker : IWorker
    {
        private ICdmExportBuilder builder;
        private IMessageStorage storage;
        private Orchestrator orchestrator;

        public CdmSubscriptionExportWorker(
            ICdmExportBuilder builder,
            IMessageStorage storage,
            Orchestrator orchestrator)
        {
            this.builder = builder;
            this.storage = storage;
            this.orchestrator = orchestrator;
        }

        public virtual void Handle(Message message)
        {
            builder.UseSubscriptions();
            var messages = builder.Build();
            storage.Save(messages);
            orchestrator.ProcessAsync(messages);
        }
    }
}
