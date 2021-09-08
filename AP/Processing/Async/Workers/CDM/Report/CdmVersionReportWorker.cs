namespace AP.Processing.Async.Workers.CDM.Report
{
    public class CdmVersionReportWorker : IWorker
    {
        private readonly ICdmReportBuilder builder;
        private readonly IMessageStorage storage;

        public CdmVersionReportWorker(
            ICdmReportBuilder builder,
            IMessageStorage storage)
        {
            this.builder = builder;
            this.storage = storage;
        }

        public virtual Message[] Handle(Message message)
        {
            var newMessage = builder.Build();
            storage.Save(newMessage);
            return new[] { newMessage };
        }
    }
}
