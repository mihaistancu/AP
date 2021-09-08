namespace AP.Async.Workers.CDM.Report
{
    public class CdmVersionReportWorker : IWorker
    {
        private readonly ICdmReportBuilder builder;

        public CdmVersionReportWorker(ICdmReportBuilder builder)
        {
            this.builder = builder;
        }

        public Message[] Handle(Message message)
        {
            System.Console.WriteLine("CdmVersion");

            var newMessage = builder.Build();

            return new[] { newMessage };
        }
    }
}
