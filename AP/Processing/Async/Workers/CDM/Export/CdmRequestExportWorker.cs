namespace AP.Processing.Async.Workers.CDM.Export
{
    public class CdmRequestExportWorker : IWorker
    {
        private readonly ICdmExportBuilder builder;

        public CdmRequestExportWorker(ICdmExportBuilder builder)
        {
            this.builder = builder;
        }

        public virtual Message[] Handle(Message message)
        {
            builder.UseRequest(message);
            return builder.Build();
        }
    }
}
