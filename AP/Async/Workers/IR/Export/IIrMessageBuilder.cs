namespace AP
{
    public interface IIrMessageBuilder
    {
        void UseRequest(Message message);
        Message Build();
        void UseSubscriptions();
    }
}