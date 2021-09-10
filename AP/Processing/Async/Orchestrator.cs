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

        public void ProcessAsync(params Message[] messages)
        {
            var workflow = config.GetWorkflow(messages[0]);
            var worker = workflow.GetFirst();
            Dispatch(worker, messages);
        }

        public void Handle(IWorker worker, Message message)
        {   
            var workflow = config.GetWorkflow(message);
            worker.Handle(message);

            if (!workflow.IsLast(worker))
            {
                var nextWorker = workflow.GetNext(worker);
                Dispatch(nextWorker, message);
            }
        }

        public abstract void Dispatch(IWorker worker, params Message[] messages);
    }
}
