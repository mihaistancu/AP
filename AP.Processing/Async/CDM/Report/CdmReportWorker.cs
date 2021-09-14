namespace AP.Processing.Async.CDM.Report
{
    public class CdmReportWorker : IWorker
    {
        private ICdmReporter reporter;

        public CdmReportWorker(ICdmReporter reporter)
        {
            this.reporter = reporter;
        }

        public virtual bool Handle(Message message)
        {
            reporter.Report(message);
            return true;
        }
    }
}
