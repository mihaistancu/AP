using AP.Data;

namespace AP.Processing.Async
{
    public interface IWorker
    {
        void Handle(Message message);
    }
}
