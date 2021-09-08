namespace AP.Processing.Async
{
    public interface IWorker
    {
        Message[] Handle(Message message);
    }
}
