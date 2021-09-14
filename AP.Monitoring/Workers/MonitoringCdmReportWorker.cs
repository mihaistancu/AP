using AP.Processing;
using AP.Processing.Async.CDM.Report;
using System;

namespace AP.Monitoring.Workers
{
    public class MonitoringCdmReportWorker: CdmReportWorker
    {
        public MonitoringCdmReportWorker(ICdmReporter publisher) : base(publisher)
        {
        }

        public override bool Handle(Message message)
        {
            Console.WriteLine("Cdm Version Report");
            return base.Handle(message);
        }
    }
}
