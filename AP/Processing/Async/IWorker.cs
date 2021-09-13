using AP.Data;

namespace AP.Processing.Async
{
    public interface IWorker
    {
        bool Handle(Message message);
    }
}
