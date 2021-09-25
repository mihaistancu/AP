using AP.Messages;
using AP.Workers;
using System;

namespace AP.Orchestration
{
    public class Orchestrator
    {
        private OrchestratorConfig config;
        private IMessageStorage storage;
        private MessageBroker broker;
        private Func<string, IWorker> getWorker;

        public Orchestrator(
            OrchestratorConfig config,
            IMessageStorage storage,
            MessageBroker broker,
            Func<string, IWorker> getWorker)
        {
            this.config = config;
            this.storage = storage;
            this.broker = broker;
            this.getWorker = getWorker;
        }

        public IDisposable Start()
        {
            config.Load();
            return broker.Start(Handle);
        }

        private void Handle(string workerName, Message message)
        {
            var workflow = config.GetWorkflow(message);
            var worker = getWorker(workerName);
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
