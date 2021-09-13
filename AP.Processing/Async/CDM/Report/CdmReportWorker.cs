namespace AP.Processing.Async.CDM.Report
{
    public class CdmReportWorker : IWorker
    {
        private ICdmReportFactory reportFactory;
        private IMessageStorage storage;
        private Orchestrator orchestrator;

        public CdmReportWorker(
            ICdmReportFactory reportFactory,
            IMessageStorage storage,
            Orchestrator orchestrator)
        {
            this.reportFactory = reportFactory;
            this.storage = storage;
            this.orchestrator = orchestrator;
        }

        public virtual bool Handle(Message message)
        {
            var newMessage = reportFactory.Get();
            storage.Save(newMessage);
            orchestrator.ProcessAsync(newMessage);
            return true;
        }
    }
}
