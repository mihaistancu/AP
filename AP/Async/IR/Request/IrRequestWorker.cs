namespace AP.Processing.Async.IR.Request
{
    public class IrRequestWorker : IWorker
    {
        private IRequestBasedIrExporter builder;
        private IMessageStorage storage;
        private Orchestrator orchestrator;

        public IrRequestWorker(
            IRequestBasedIrExporter builder,
            IMessageStorage storage,
            Orchestrator orchestrator)
        {
            this.builder = builder;
            this.storage = storage;
            this.orchestrator = orchestrator;
        }

        public virtual bool Handle(Message message)
        {
            var newMessage = builder.Export(message);
            storage.Save(newMessage);
            orchestrator.ProcessAsync(newMessage);
            return true;
        }
    }
}
