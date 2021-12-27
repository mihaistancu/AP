using AP.Messages;

namespace AP.Gateways
{
    public interface IMessageQueue
    {
        void Enqueue(string channel, Message message);

        Message Dequeue(string channel);
    }
}
