namespace AP.Processing.Async.Synchronization
{
    public interface IGateway
    {
        void Deliver(Message message);
    }
}
