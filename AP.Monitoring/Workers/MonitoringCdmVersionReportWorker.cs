using AP.Processing.Async.Workers.CDM.Report;
using System;

namespace AP.Monitoring.Workers
{
    public class MonitoringCdmVersionReportWorker: CdmVersionReportWorker
    {
        public MonitoringCdmVersionReportWorker(ICdmReportBuilder builder, IMessageStorage storage) : base(builder, storage)
        {
        }

        public override Message[] Handle(Message message)
        {
            Console.WriteLine("Cdm Version Report");
            return base.Handle(message);
        }
    }
}
