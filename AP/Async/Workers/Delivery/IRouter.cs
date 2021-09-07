namespace AP.Async.Workers.Delivery
{
    public interface IRouter
    {
        void Route(Message message);
    }
}
