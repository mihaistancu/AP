using AP.Processing;
using AP.Processing.Async.Delivery;
using System;

namespace AP.Monitoring.Workers
{
    public class MonitoringDeliverWorker : DeliveryWorker
    {
        public MonitoringDeliverWorker(IGateway gateway) : base(gateway)
        {
        }

        public override bool Handle(Message message)
        {
            Console.WriteLine("Delivery");
            return base.Handle(message);
        }
    }
}
