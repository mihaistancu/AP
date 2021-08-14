namespace AP.Processing
{
    public interface IWorker
    {
        void Process(Work input, IWorkflow workflow);
    }
}
