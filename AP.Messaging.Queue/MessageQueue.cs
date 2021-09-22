using AP.Gateways.Institution;
using AP.Processing;

namespace AP.Messaging.Queue
{
    public class MessageQueue : IMessageQueue
    {
        public virtual void Enqueue(string channel, Message message)
        {

        }

        public virtual Message Dequeue(string channel)
        {
            return new Message();
        }
    }
}
