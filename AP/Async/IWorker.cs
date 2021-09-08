namespace AP.Async
{
    public interface IWorker
    {
        Message[] Handle(Message message);
    }
}
