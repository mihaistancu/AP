using AP.Processing.Async.Workers.Delivery;
using System;

namespace AP.Monitoring.Workers
{
    public class MonitoringDeliverWorker : DeliveryWorker
    {
        public MonitoringDeliverWorker(IRouter router) : base(router)
        {
        }

        public override Message[] Handle(Message message)
        {
            Console.WriteLine("Delivery");
            return base.Handle(message);
        }
    }
}
