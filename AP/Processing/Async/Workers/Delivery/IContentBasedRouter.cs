using AP.Data;

namespace AP.Processing.Async.Workers.Delivery
{
    public interface IContentBasedRouter
    {
        void Route(Message message);
    }
}
