namespace AP.Processing.Async
{
    public interface IGateway
    {
        void Deliver(Message message);
    }
}
