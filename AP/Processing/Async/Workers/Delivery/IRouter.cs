namespace AP.Processing.Async.Workers.Delivery
{
    public interface IRouter
    {
        void Route(Message message);
    }
}
