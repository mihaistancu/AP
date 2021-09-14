using AP.Processing;
using AP.Processing.Async;
using AP.Processing.Async.IR.Subscriptions;
using System;

namespace AP.Monitoring.Workers
{
    public class MonitoringIrSubscriptionsWorker : IrSubscriptionsWorker
    {
        public MonitoringIrSubscriptionsWorker(IIrSubscriptionsPublisher publisher) : base(publisher)
        {
        }

        public override bool Handle(Message message)
        {
            Console.WriteLine("Ir Subscription Export");
            return base.Handle(message);
        }
    }
}
