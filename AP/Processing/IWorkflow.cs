namespace AP.Processing
{
    public interface IWorkflow
    {
        void Done(IWorker worker, WorkerOutput output);
        void Start(Message message);
    }
}
