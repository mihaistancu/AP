namespace AP.Receiver
{
    public interface IHandler
    {
        bool Handle(Message message);
    }
}