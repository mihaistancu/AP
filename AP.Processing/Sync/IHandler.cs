namespace AP.Processing.Sync
{
    public interface IHandler
    {
        (bool, Message) Handle(Message message);
    }
}