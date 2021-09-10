using AP.Data;
using AP.Processing.Async;

namespace AP.Processing.Sync.Handlers.AsyncProcessing
{
    public class AsyncProcessingHandler : IHandler
    {
        private Orchestrator orchestrator;

        public AsyncProcessingHandler(Orchestrator orchestrator)
        {
            this.orchestrator = orchestrator;
        }

        public bool Handle(Message message, IOutput output)
        {
            orchestrator.ProcessAsync(message);
            return true;
        }
    }
}
