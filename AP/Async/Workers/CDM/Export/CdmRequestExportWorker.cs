namespace AP.Async.Workers.CDM.Export
{
    public class CdmRequestExportWorker : Worker
    {
        private readonly ICdmExportBuilder builder;

        public CdmRequestExportWorker(ICdmExportBuilder builder)
        {
            this.builder = builder;
        }

        public override void Do(Work work)
        {
            System.Console.WriteLine("CdmRequestExport");

            builder.UseRequest(work.Message);
            var newMessages = builder.Build();

            work.Workflow.Next(work, newMessages);
        }
    }
}
