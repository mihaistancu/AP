using AP.Messages;
using System;

namespace AP.Orchestration
{
    public class Orchestrator
    {
        private OrchestratorConfig config;
        private IMessageStorage storage;
        private MessageBroker broker;
        private IWorkerFactory factory;

        public Orchestrator(
            OrchestratorConfig config,
            IMessageStorage storage,
            MessageBroker broker,
            IWorkerFactory factory)
        {
            this.config = config;
            this.storage = storage;
            this.broker = broker;
            this.factory = factory;
        }

        public IDisposable Start()
        {
            config.Load();
            return broker.Start(Handle);
        }

        private void Handle(string workerName, Message message)
        {
            var workflow = config.GetWorkflow(message);
            var worker = factory.Get(workerName);
            bool canContinue = worker.Handle(message);

            if (canContinue && !workflow.IsLast(workerName))
            {
                var nextWorkerName = workflow.GetNext(workerName);
                broker.Send(nextWorkerName, message);
            }
            else
            {
                storage.SetProcessed(message);
            }
        }

        public virtual void ProcessAsync(Message message)
        {
            var workflow = config.GetWorkflow(message);
            var workerName = workflow.GetFirst();
            broker.Send(workerName, message);
        }
    }
}
