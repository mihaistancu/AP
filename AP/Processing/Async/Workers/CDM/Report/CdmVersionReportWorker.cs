namespace AP.Processing.Async.Workers.CDM.Report
{
    public class CdmVersionReportWorker : IWorker
    {
        private readonly ICdmReportBuilder builder;

        public CdmVersionReportWorker(ICdmReportBuilder builder)
        {
            this.builder = builder;
        }

        public virtual Message[] Handle(Message message)
        {
            var newMessage = builder.Build();

            return new[] { newMessage };
        }
    }
}
