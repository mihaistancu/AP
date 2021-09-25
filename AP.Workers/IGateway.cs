using AP.Messaging;

namespace AP.Workers
{
    public interface IGateway
    {
        void Deliver(Message message);
    }
}
