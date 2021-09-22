using AP.Processing;
using AP.Processing.Async;
using AP.Processing.Async.Synchronization.IR.Subscriptions;
using System;

namespace AP.Monitoring.Workers
{
    public class MonitoredIrSubscriptionsWorker : IrSubscriptionsWorker
    {
        public MonitoredIrSubscriptionsWorker(IIrPublisher publisher) : base(publisher)
        {
        }

        public override bool Handle(Message message)
        {
            Console.WriteLine("Ir Subscriptions");
            return base.Handle(message);
        }
    }
}
