using System.Collections.Generic;

namespace AP.Async.Workers.CDM.Report
{
    public class CdmVersionReportWorker : IWorker
    {
        private readonly ICdmReportBuilder builder;

        public CdmVersionReportWorker(ICdmReportBuilder builder)
        {
            this.builder = builder;
        }

        public IEnumerable<Message> Handle(Message message)
        {
            System.Console.WriteLine("CdmVersion");

            var newMessage = builder.Build();

            yield return newMessage;
        }
    }
}
