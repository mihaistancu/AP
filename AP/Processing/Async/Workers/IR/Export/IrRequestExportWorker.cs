using AP.Data;

namespace AP.Processing.Async.Workers.IR.Export
{
    public class IrRequestExportWorker : IWorker
    {
        private IIrExportBuilder builder;
        private IMessageStorage storage;
        private Orchestrator orchestrator;

        public IrRequestExportWorker(
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
            builder.UseRequest(message);
            var messages = builder.Build();
            storage.Save(messages);
            orchestrator.ProcessAsync(messages);
        }
    }
}
