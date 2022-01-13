using AP.Messages;

namespace AP.Workers
{
    public interface IGateway
    {
        void Deliver(Message message);
    }
}
