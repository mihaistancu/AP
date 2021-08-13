namespace AP.Processing
{
    public interface IWorker
    {
        void Process(WorkerInput input, IWorkflow workflow);
    }
}
