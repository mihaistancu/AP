using AP.Processing.Async.CDM.Export;

namespace AP.Processing.Async.CDM.Request
{
    public class CdmRequestWorker : IWorker
    {
        private IRequestBasedCdmExporter exporter;
        private IMessageStorage storage;
        private Orchestrator orchestrator;

        public CdmRequestWorker(
            IRequestBasedCdmExporter exporter,
            IMessageStorage storage,
            Orchestrator orchestrator)
        {
            this.exporter = exporter;
            this.storage = storage;
            this.orchestrator = orchestrator;
        }

        public virtual bool Handle(Message message)
        {
            var newMessage = exporter.Export(message);
            storage.Save(newMessage);
            orchestrator.ProcessAsync(newMessage);
            return true;
        }
    }
}
