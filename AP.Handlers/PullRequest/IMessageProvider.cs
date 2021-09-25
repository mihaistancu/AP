using AP.Messages;

namespace AP.Handlers.PullRequest
{
    public interface IMessageProvider
    {
        Message Get(Message message);
    }
}
