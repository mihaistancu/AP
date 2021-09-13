using AP.Data;
using AP.Processing.Async;
using AP.Processing.Async.IR.Subscriptions;
using System;

namespace AP.Monitoring.Workers
{
    public class MonitoringIrSubscriptionsWorker : IrSubscriptionsExportWorker
    {
        public MonitoringIrSubscriptionsWorker(
            ISubscriptionBasedIrExporter exporter, 
            IMessageStorage storage, 
            Orchestrator orchestrator) 
            : base(exporter, storage, orchestrator)
        {
        }

        public override bool Handle(Message message)
        {
            Console.WriteLine("Ir Subscription Export");
            return base.Handle(message);
        }
    }
}
