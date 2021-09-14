namespace AP.Processing.Async.IR.Subscriptions
{
    public class IrSubscriptionsWorker : IWorker
    {
        private ISubscriptionBasedIrExporter exporter;
        private IMessageStorage storage;
        private Orchestrator orchestrator;

        public IrSubscriptionsWorker(
            ISubscriptionBasedIrExporter exporter,
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
