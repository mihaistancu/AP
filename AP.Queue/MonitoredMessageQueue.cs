using AP.Gateways;
using AP.Instrumentation;
using AP.Messages;

namespace AP.Monitoring
{
    public class MonitoredMessageQueue: IMessageQueue
    {
        private ILog log;
        private IMessageQueue queue;

        public MonitoredMessageQueue(ILog log, IMessageQueue queue)
        {
            this.log = log;
            this.queue = queue;
        }

        public void Enqueue(string channel, Message message)
        {
            log.Debug("Queue");
            queue.Enqueue(channel, message);
        }

        public Message Dequeue(string channel)
        {
            log.Debug("Dequeue");
            return queue.Dequeue(channel);
        }
    }
}
