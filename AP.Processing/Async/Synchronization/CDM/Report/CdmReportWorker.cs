namespace AP.Processing.Async.Synchronization.CDM.Report
{
    public class CdmReportWorker : IWorker
    {
        private ICdmReporter reporter;
        private IGateway gateway;

        public CdmReportWorker(ICdmReporter reporter, IGateway gateway)
        {
            this.reporter = reporter;
            this.gateway = gateway;
        }

        public virtual bool Handle(Message message)
        {
            var newMessage = reporter.GetReport();
            gateway.Deliver(newMessage);
            return true;
        }
    }
}
