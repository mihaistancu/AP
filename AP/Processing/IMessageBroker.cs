namespace AP.Processing
{
    public interface IMessageBroker
    {
        void Send(Work input);
    }
}