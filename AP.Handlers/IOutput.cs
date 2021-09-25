using AP.Messages;

namespace AP.Handlers
{
    public interface IOutput
    {
        void Send(Message message);

        bool IsMessageSent();
    }
}
