namespace AP.Processing.Async.Delivery
{
    public interface IGateway
    {
        void Deliver(Message message);
    }
}
