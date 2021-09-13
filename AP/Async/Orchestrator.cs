namespace AP.Processing.Async
{
    public abstract class Orchestrator
    {
        private IOrchestratorConfig config;
        private IMessageStorage storage;

        public Orchestrator(IOrchestratorConfig config, IMessageStorage storage)
        {
            this.config = config;
            this.storage = storage;
        }

        public virtual void ProcessAsync(params Message[] messages)
        {
            var workflow = config.GetWorkflow(messages[0]);
            var worker = workflow.GetFirst();
            Dispatch(worker, messages);
        }

        public virtual void Handle(IWorker worker, Message message)
        {   
            var workflow = config.GetWorkflow(message);
            bool canContinue = worker.Handle(message);

            if (canContinue && !workflow.IsLast(worker))
            {
                var nextWorker = workflow.GetNext(worker);
                Dispatch(nextWorker, message);
            }
            else
            {
                storage.SetProcessed(message);
            }
        }

        public abstract void Dispatch(IWorker worker, params Message[] messages);
    }
}
