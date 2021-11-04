using AP.Workers;

namespace AP.Orchestration
{
    public interface IWorkerFactory
    {
        IWorker Get(string workerName); 
    }
}
