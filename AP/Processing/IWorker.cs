namespace AP.Processing
{
    public interface IWorker
    {
        WorkerOutput Process(WorkerInput input);
    }
}
