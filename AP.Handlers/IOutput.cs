using AP.Messaging;

namespace AP.Handlers
{
    public interface IOutput
    {
        void Send(Message message);

        bool IsMessageSent();
    }
}
