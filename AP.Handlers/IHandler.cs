using AP.Messaging;

namespace AP.Handlers
{
    public interface IHandler
    {
        void Handle(Message message, IOutput output);
    }
}