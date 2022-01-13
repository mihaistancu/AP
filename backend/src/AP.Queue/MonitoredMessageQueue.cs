using AP.Gateways;
using AP.Instrumentation;
using AP.Messages;

namespace AP.Monitoring
{
    public class MonitoredMessageQueue: IMessageQueue
    {
        private ITrace trace;
        private IMessageQueue queue;

        public MonitoredMessageQueue(ITrace trace, IMessageQueue queue)
        {
            this.trace = trace;
            this.queue = queue;
        }

        public void Enqueue(string channel, Message message)
        {
            using (trace.Start("Enqueue"))
            {
                queue.Enqueue(channel, message);
            }
        }

        public Message Dequeue(string channel)
        {
            using (trace.Start("Dequeue"))
            {
                return queue.Dequeue(channel);
            }
        }
    }
}
