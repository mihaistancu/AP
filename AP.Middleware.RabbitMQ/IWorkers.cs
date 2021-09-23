using AP.Processing.Async;

namespace AP.Middleware.RabbitMQ
{
    public interface IWorkers
    {
        IWorker Worker(string id);
        string Id(IWorker worker);
    }
}
