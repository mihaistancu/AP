using AP.Messages;
using AP.Queue;
using System;

namespace AP.Monitoring
{
    public class MonitoredMessageQueue: MessageQueue
    {
        public override void Enqueue(string channel, Message message)
        {
            Console.WriteLine("Queue");
            base.Enqueue(channel, message);
        }

        public override Message Dequeue(string channel)
        {
            Console.WriteLine("Dequeue");
            return base.Dequeue(channel);
        }
    }
}
