using AP.Processing.Async.Workers.CDM.Report;
using System;

namespace AP.Monitoring.Workers
{
    public class MonitoringCdmVersionReportWorker: CdmVersionReportWorker
    {
        public MonitoringCdmVersionReportWorker(ICdmReportBuilder builder) : base(builder)
        {
        }

        public override Message[] Handle(Message message)
        {
            Console.WriteLine("Cdm Version Report");
            return base.Handle(message);
        }
    }
}
