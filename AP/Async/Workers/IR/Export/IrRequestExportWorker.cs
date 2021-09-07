using System.Collections.Generic;

namespace AP.Async.Workers.IR.Export
{
    public class IrRequestExportWorker : IWorker
    {
        private IIrExportBuilder builder;

        public IrRequestExportWorker(IIrExportBuilder builder)
        {
            this.builder = builder;
        }

        public IEnumerable<Message> Handle(Message message)
        {
            System.Console.WriteLine("IrRequestExport");

            builder.UseRequest(message);
            var newMessages = builder.Build();

            return newMessages;
        }
    }
}
