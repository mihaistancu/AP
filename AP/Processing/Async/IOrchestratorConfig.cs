using AP.Data;

namespace AP.Processing.Async
{
    public interface IOrchestratorConfig
    {
        Workflow GetWorkflow(Message message);
    }
}
