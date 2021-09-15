using AP.Processing.Async;

namespace AP.Processing.Sync.AsyncProcessing
{
    public class AsyncProcessingHandler : IHandler
    {
        private Orchestrator orchestrator;

        public AsyncProcessingHandler(Orchestrator orchestrator)
        {
            this.orchestrator = orchestrator;
        }

        public (bool, Message) Handle(Message message)
        {
            orchestrator.ProcessAsync(message);
            return (true, null);
        }
    }
}
