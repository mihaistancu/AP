namespace AP.Async.Workers.IR.Export
{
    public class IrSubscriptionExportWorker : IWorker
    {
        private IIrExportBuilder builder;

        public IrSubscriptionExportWorker(IIrExportBuilder builder)
        {
            this.builder = builder;
        }

        public Message[] Handle(Message message)
        {
            System.Console.WriteLine("IrSubscriptionExport");

            builder.UseSubscriptions();
            var newMessages = builder.Build();

            return newMessages;
        }
    }
}
