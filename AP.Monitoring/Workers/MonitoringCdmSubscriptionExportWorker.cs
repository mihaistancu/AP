using AP.Processing.Async.Workers.CDM.Export;
using System;

namespace AP.Monitoring.Workers
{
    public class MonitoringCdmSubscriptionExportWorker: CdmSubscriptionExportWorker
    {
        public MonitoringCdmSubscriptionExportWorker(ICdmExportBuilder builder) : base(builder)
        {
        }

        public override Message[] Handle(Message message)
        {
            Console.WriteLine("Cdm Subscription Export");
            return base.Handle(message);
        }
    }
}
