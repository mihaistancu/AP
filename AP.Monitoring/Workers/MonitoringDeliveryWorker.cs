using AP.Processing;
using AP.Processing.Async.Forwarding;
using System;

namespace AP.Monitoring.Workers
{
    public class MonitoringForwardingWorker : ForwardingWorker
    {
        public MonitoringForwardingWorker(
            IRoutingConfig config, 
            IRouter router) 
            : base(config, router)
        {
        }

        public override bool Handle(Message message)
        {
            Console.WriteLine("Forwarding");
            return base.Handle(message);
        }
    }
}
