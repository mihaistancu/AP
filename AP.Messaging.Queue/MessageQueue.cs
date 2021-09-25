using AP.Gateways.Institution;
using AP.Messages;

namespace AP.Queue
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
