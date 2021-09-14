namespace AP.Processing.Async.CDM.Report
{
    public class CdmReportWorker : IWorker
    {
        private ICdmReporter publisher;

        public CdmReportWorker(ICdmReporter publisher)
        {
            this.publisher = publisher;
        }

        public virtual bool Handle(Message message)
        {
            publisher.Report();
            return true;
        }
    }
}
