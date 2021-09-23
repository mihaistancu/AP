namespace AP.Processing.Async
{
    public interface IWorkers
    {
        IWorker Worker(string name);
        string Name(IWorker worker);
    }
}