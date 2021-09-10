using AP.Data;
using AP.Processing.Async;
using AP.Processing.Async.Workers.IR.Export;
using System;

namespace AP.Monitoring.Workers
{
    public class MonitoringIrSubscriptionExportWorker : IrSubscriptionExportWorker
    {
        public MonitoringIrSubscriptionExportWorker(
            IIrExportBuilder builder, 
            IMessageStorage storage,
            Orchestrator orchestrator) 
            : base(builder, storage, orchestrator)
        {
        }

        public override void Handle(Message message)
        {
            Console.WriteLine("Ir Subscription Export");
            base.Handle(message);
        }
    }
}
