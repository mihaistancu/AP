using System.Collections.Generic;

namespace AP.Async.Workers.CDM.Export
{
    public class CdmRequestExportWorker : IWorker
    {
        private readonly ICdmExportBuilder builder;

        public CdmRequestExportWorker(ICdmExportBuilder builder)
        {
            this.builder = builder;
        }

        public IEnumerable<Message> Handle(Message message)
        {
            System.Console.WriteLine("CdmRequestExport");

            builder.UseRequest(message);
            var newMessages = builder.Build();

            return newMessages;
        }
    }
}
