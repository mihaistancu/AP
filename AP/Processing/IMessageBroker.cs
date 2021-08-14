namespace AP.Processing
{
    public interface IMessageBroker
    {
        void Send(Message message);
        void Send(Work input);
    }
}