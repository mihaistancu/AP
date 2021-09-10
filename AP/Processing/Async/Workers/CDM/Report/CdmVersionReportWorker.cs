using AP.Data;

namespace AP.Processing.Async.Workers.CDM.Report
{
    public class CdmVersionReportWorker : IWorker
    {
        private ICdmReportBuilder builder;
        private IMessageStorage storage;
        private Orchestrator orchestrator;

        public CdmVersionReportWorker(
            ICdmReportBuilder builder,
            IMessageStorage storage,
            Orchestrator orchestrator)
        {
            this.builder = builder;
            this.storage = storage;
            this.orchestrator = orchestrator;
        }

        public virtual void Handle(Message message)
        {
            var newMessage = builder.Build();
            storage.Save(newMessage);
            orchestrator.ProcessAsync(newMessage);
        }
    }
}
