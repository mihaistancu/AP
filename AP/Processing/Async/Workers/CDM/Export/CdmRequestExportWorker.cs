using AP.Data;

namespace AP.Processing.Async.Workers.CDM.Export
{
    public class CdmRequestExportWorker : IWorker
    {
        private Orchestrator orchestrator;
        private ICdmExportBuilder builder;
        private IMessageStorage storage;
        
        public CdmRequestExportWorker(
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
            builder.UseRequest(message);
            var messages = builder.Build();
            storage.Save(messages);
            orchestrator.ProcessAsync(messages);
        }
    }
}
