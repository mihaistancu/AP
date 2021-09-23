namespace AP.Processing.Async
{
    public interface IWorkers
    {
        IWorker Worker(string workerId);
        string Id(IWorker worker);
    }
}