namespace AP.Messaging
{
    public interface IMessageStorage
    {
        void Save(params Message[] messages);
        Message Read(string id);
        void SetProcessed(Message message);
    }
}
