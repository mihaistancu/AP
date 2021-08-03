namespace AP
{
    public interface IWorker
    {
        WorkerOutput Process(WorkerInput input);
    }
}
