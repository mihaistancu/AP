namespace AP.Async
{
    public interface IWorkflow
    {
        void Next(Work work);
        void Start(Work work);
    }
}
