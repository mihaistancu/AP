using AP.Processing;
using AP.Processing.Async;
using AP.Processing.Async.Synchronization.CDM.Subscriptions;
using System;

namespace AP.Monitoring.Workers
{
    public class MonitoredCdmSubscriptionsWorker: CdmSubscriptionsWorker
    {
        public MonitoredCdmSubscriptionsWorker(ICdmPublisher publisher) : base(publisher)
        {
        }

        public override bool Handle(Message message)
        {
            Console.WriteLine("Cdm Subscriptions");
            return base.Handle(message);
        }
    }
}
