using AP.Inbox;
using AP.Processing;
using System;

namespace AP.Monitoring
{
    public class MonitoringQueue: Queue
    {
        public override void Enqueue(string channel, params Message[] messages)
        {
            Console.WriteLine("Queue");
            base.Enqueue(channel, messages);
        }
    }
}
