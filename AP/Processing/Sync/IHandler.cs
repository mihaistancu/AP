namespace AP.Processing.Sync
{
    public interface IHandler
    {
        bool Handle(Message message);
    }
}