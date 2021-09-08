using AP.Processing.Async.Workers.CDM.Export;
using System;

namespace AP.Monitoring.Workers
{
    public class MonitoringCdmRequestExportWorker: CdmRequestExportWorker
    {
        public MonitoringCdmRequestExportWorker(ICdmExportBuilder builder) : base(builder)
        {
        }

        public override Message[] Handle(Message message)
        {
            Console.WriteLine("Cdm Request Export");
            return base.Handle(message);
        }
    }
}
