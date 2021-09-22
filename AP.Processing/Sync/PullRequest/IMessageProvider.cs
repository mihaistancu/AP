namespace AP.Processing.Sync.PullRequest
{
    public interface IMessageProvider
    {
        Message Get(Message message);
    }
}
