namespace AP.Async
{
    public interface IMessageBroker
    {
        void Send(Work input);
    }
}