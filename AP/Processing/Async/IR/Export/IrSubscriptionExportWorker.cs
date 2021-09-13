using AP.Data;

namespace AP.Processing.Async.IR.Export
{
    public class IrSubscriptionExportWorker : IWorker
    {
        private IIrExportBuilder builder;
        private IMessageStorage storage;
        private Orchestrator orchestrator;

        public IrSubscriptionExportWorker(
            IIrExportBuilder builder,
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
