namespace AP.Processing
{
    public interface IWorkflowFactory
    {
        IWorkflow Get(string sedType);
    }
}
