using AP.Data;

namespace AP.Processing.Async.Delivery
{
    public interface IContentBasedRouter
    {
        void Route(Message message);
    }
}
