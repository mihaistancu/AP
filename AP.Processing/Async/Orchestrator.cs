namespace AP.Processing.Async
{
    public class Orchestrator
    {
        private IOrchestratorConfig config;
        private IMessageStorage storage;
        private MessageBroker broker;

        public Orchestrator(
            IOrchestratorConfig config, 
            IMessageStorage storage,
            MessageBroker broker)
        {
            this.config = config;
            this.storage = storage;
            this.broker = broker;
        }

        public void Start()
        {
            broker.Start(Handle);
        }

        private void Handle(IWorker worker, Message message)
        {
            var workflow = config.GetWorkflow(message);
            bool canContinue = worker.Handle(message);

            if (canContinue && !workflow.IsLast(worker))
            {
                var nextWorker = workflow.GetNext(worker);
                broker.Send(nextWorker, message);
            }
            else
            {
                storage.SetProcessed(message);
            }
        }

        public virtual void ProcessAsync(Message message)
        {
            var workflow = config.GetWorkflow(message);
            var worker = workflow.GetFirst();
            broker.Send(worker, message);
        }
    }
}
