namespace AP.Async.Workers.CDM.Report
{
    public class CdmVersionReportWorker : Worker
    {
        private readonly ICdmReportBuilder builder;

        public CdmVersionReportWorker(ICdmReportBuilder builder)
        {
            this.builder = builder;
        }

        public override void Do(Work work)
        {
            System.Console.WriteLine("CdmVersion");

            var newMessage = builder.Build();

            work.Workflow.Next(work, new[] { newMessage });
        }
    }
}
