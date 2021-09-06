namespace AP.Sync
{
    public interface IHandler
    {
        bool Handle(Message message);
    }
}