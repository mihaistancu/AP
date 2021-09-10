using AP.Data;
using AP.Processing.Async.Workers.Delivery;
using System;

namespace AP.Monitoring.Workers
{
    public class MonitoringDeliverWorker : DeliveryWorker
    {
        public MonitoringDeliverWorker(IContentBasedRouter router) : base(router)
        {
        }

        public override void Handle(Message message)
        {
            Console.WriteLine("Delivery");
            base.Handle(message);
        }
    }
}
