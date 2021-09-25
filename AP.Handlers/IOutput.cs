namespace AP.Processing.Sync
{
    public interface IOutput
    {
        void Send(Message message);

        bool IsMessageSent();
    }
}
