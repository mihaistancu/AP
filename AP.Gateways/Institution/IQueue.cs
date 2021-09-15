using AP.Processing;

namespace AP.Routing
{
    public interface IQueue
    {
        void Enqueue(string channel, Message message);
    }
}
