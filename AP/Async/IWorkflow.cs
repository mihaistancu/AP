namespace AP.Async
{
    public interface IWorkflow
    {
        void Done(Work work);
        void Start(Work work);
    }
}
