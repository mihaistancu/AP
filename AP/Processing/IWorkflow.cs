namespace AP.Processing
{
    public interface IWorkflow
    {
        void Done(Work work);
        void Start(Work work);
    }
}
