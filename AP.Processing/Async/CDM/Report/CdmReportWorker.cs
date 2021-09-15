namespace AP.Processing.Async.CDM.Report
{
    public class CdmReportWorker<T> : IWorker where T: IGateway
    {
        private ICdmReporter reporter;
        private T gateway;

        public CdmReportWorker(ICdmReporter reporter, T gateway)
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
