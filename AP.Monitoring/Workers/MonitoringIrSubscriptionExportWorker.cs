using AP.Data;
using AP.Processing.Async.Workers.IR.Export;
using System;

namespace AP.Monitoring.Workers
{
    public class MonitoringIrSubscriptionExportWorker : IrSubscriptionExportWorker
    {
        public MonitoringIrSubscriptionExportWorker(IIrExportBuilder builder, IMessageStorage storage) : base(builder, storage)
        {
        }

        public override Message[] Handle(Message message)
        {
            Console.WriteLine("Ir Subscription Export");
            return base.Handle(message);
        }
    }
}
