using AP.Processing.Async.CDM.Subscriptions;

namespace AP.Processing.Async.CDM.Export
{
    public class CdmSubscriptionsWorker : IWorker
    {
        private ISubscriptionBasedCdmExporter exporter;
        private IMessageStorage storage;
        private Orchestrator orchestrator;

        public CdmSubscriptionsWorker(
            ISubscriptionBasedCdmExporter exporter,
            IMessageStorage storage,
            Orchestrator orchestrator)
        {
            this.exporter = exporter;
            this.storage = storage;
            this.orchestrator = orchestrator;
        }

        public virtual bool Handle(Message message)
        {
            var messages = exporter.Export();
            storage.Save(messages);
            orchestrator.ProcessAsync(messages);
            return true;
        }
    }
}
