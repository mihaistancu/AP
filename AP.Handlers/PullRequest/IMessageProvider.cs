using AP.Messaging;

namespace AP.Handlers.PullRequest
{
    public interface IMessageProvider
    {
        Message Get(Message message);
    }
}
