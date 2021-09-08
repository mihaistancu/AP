namespace AP.Async.Workers.IR.Export
{
    public class IrRequestExportWorker : IWorker
    {
        private IIrExportBuilder builder;

        public IrRequestExportWorker(IIrExportBuilder builder)
        {
            this.builder = builder;
        }

        public Message[] Handle(Message message)
        {
            System.Console.WriteLine("IrRequestExport");

            builder.UseRequest(message);
            var newMessages = builder.Build();

            return newMessages;
        }
    }
}
