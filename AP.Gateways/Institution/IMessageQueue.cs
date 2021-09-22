using AP.Processing;

namespace AP.Gateways.Institution
{
    public interface IMessageQueue
    {
        void Enqueue(string channel, Message message);
    }
}
