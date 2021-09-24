using AP.Gateways.Institution;
using AP.Processing;
using System;

namespace AP.Monitoring
{
    public class MonitoredMessageQueue: IMessageQueue
    {
        private IMessageQueue queue;

        public MonitoredMessageQueue(IMessageQueue queue)
        {
            this.queue = queue;
        }

        public void Enqueue(string channel, Message message)
        {
            Console.WriteLine("Queue");
            queue.Enqueue(channel, message);
        }
    }
}
