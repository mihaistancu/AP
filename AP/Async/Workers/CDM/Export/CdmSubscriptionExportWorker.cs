using System.Collections.Generic;

namespace AP.Async.Workers.CDM.Export
{
    public class CdmSubscriptionExportWorker : IWorker
    {
        private readonly ICdmExportBuilder builder;

        public CdmSubscriptionExportWorker(ICdmExportBuilder builder)
        {
            this.builder = builder;
        }

        public IEnumerable<Message> Handle(Message message)
        {
            System.Console.WriteLine("CdmSubscriptionExport");

            builder.UseSubscriptions();
            var newMessages = builder.Build();

            return newMessages;
        }
    }
}
