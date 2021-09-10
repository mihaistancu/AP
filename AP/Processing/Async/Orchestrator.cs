using AP.Data;

namespace AP.Processing.Async
{
    public abstract class Orchestrator
    {
        private IOrchestratorConfig config;

        public Orchestrator(IOrchestratorConfig config)
        {
            this.config = config;
        }

        public void ProcessAsync(Message message)
        {
            var workflow = config.GetWorkflow(message);
            var worker = workflow.GetFirst();
            Dispatch(worker, message);
        }

        public void Handle(IWorker worker, Message message)
        {   
            var workflow = config.GetWorkflow(message);
            var messages = worker.Handle(message);

            if (!workflow.IsLast(worker))
            {
                var nextWorker = workflow.GetNext(worker);
                Dispatch(nextWorker, messages);
            }
        }

        public abstract void Dispatch(IWorker worker, params Message[] messages);
    }
}
