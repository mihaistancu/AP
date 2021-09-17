namespace AP.Processing.Sync.PullRequest
{
    public interface IInbox
    {
        Message Get(Message message);
    }
}
