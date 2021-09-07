namespace AP.Async.Workers.IR.Export
{
    public class IrSubscriptionExportWorker : Worker
    {
        private IIrMessageBuilder builder;

        public IrSubscriptionExportWorker(IIrMessageBuilder builder)
        {
            this.builder = builder;
        }

        public override void Do(Work work)
        {
            System.Console.WriteLine("IrSubscriptionExport");

            builder.UseSubscriptions();
            var newMessages = builder.Build();

            work.Workflow.Next(work, newMessages);
        }
    }
}
