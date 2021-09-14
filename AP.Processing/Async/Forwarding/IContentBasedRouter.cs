namespace AP.Processing.Async.Forwarding
{
    public interface IContentBasedRouter
    {
        void Route(Message message);
    }
}
