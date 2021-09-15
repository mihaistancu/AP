using AP.Processing;
using AP.Processing.Async.Forwarding;
using System;

namespace AP.Monitoring.Workers
{
    public class MonitoringForwardingWorker<T> : ForwardingWorker<T> where T: IGateway
    {
        public MonitoringForwardingWorker(T gateway) : base(gateway)
        {
        }

        public override bool Handle(Message message)
        {
            Console.WriteLine("Forwarding");
            return base.Handle(message);
        }
    }
}
