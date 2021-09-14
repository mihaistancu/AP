using AP.Processing;
using AP.Processing.Async;
using AP.Processing.Async.CDM.Export;
using AP.Processing.Async.CDM.Subscriptions;
using System;

namespace AP.Monitoring.Workers
{
    public class MonitoringCdmSubscriptionsWorker: CdmSubscriptionsWorker
    {
        public MonitoringCdmSubscriptionsWorker(ICdmPublisher publisher) : base(publisher)
        {
        }

        public override bool Handle(Message message)
        {
            Console.WriteLine("Cdm Subscription Export");
            return base.Handle(message);
        }
    }
}
