using AP.Messaging;

namespace AP.Workers
{
    public interface IWorker
    {
        bool Handle(Message message);
    }
}
