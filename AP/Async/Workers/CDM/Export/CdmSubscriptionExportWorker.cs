namespace AP.Async.Workers.CDM.Export
{
    public class CdmSubscriptionExportWorker : Worker
    {
        private readonly ICdmExportBuilder builder;

        public CdmSubscriptionExportWorker(ICdmExportBuilder builder)
        {
            this.builder = builder;
        }

        public override void Do(Work work)
        {
            System.Console.WriteLine("CdmSubscriptionExport");

            builder.UseSubscriptions();
            var newMessages = builder.Build();

            work.Workflow.Next(work, newMessages);
        }
    }
}
