namespace AP.Processing.Async.Workers.CDM.Export
{
    public class CdmSubscriptionExportWorker : IWorker
    {
        private readonly ICdmExportBuilder builder;

        public CdmSubscriptionExportWorker(ICdmExportBuilder builder)
        {
            this.builder = builder;
        }

        public virtual Message[] Handle(Message message)
        {
            builder.UseSubscriptions();
            return builder.Build();
        }
    }
}
