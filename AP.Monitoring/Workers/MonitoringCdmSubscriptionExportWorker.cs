using AP.Data;
using AP.Processing.Async;
using AP.Processing.Async.CDM.Export;
using System;

namespace AP.Monitoring.Workers
{
    public class MonitoringCdmSubscriptionExportWorker: CdmSubscriptionExportWorker
    {
        public MonitoringCdmSubscriptionExportWorker(
            ICdmExportBuilder builder,
            IMessageStorage storage,
            Orchestrator orchestrator) 
            : base(builder, storage, orchestrator)
        {
        }

        public override void Handle(Message message)
        {
            Console.WriteLine("Cdm Subscription Export");
            base.Handle(message);
        }
    }
}
