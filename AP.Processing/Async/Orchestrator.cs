using System.Collections.Generic;
using System.Linq;

namespace AP.Processing.Async
{
    public class Orchestrator
    {
        private List<Rule> routes = new List<Rule>();
        private IMessageStorage storage;
        private MessageBroker broker;

        public Orchestrator(IMessageStorage storage, MessageBroker broker)
        {
            this.storage = storage;
            this.broker = broker;
        }

        public void Use(Rule route)
        {
            routes.Add(route);
        }

        public void Start()
        {
            broker.Start(Handle);
        }

        private void Handle(IWorker worker, Message message)
        {
            var workflow = GetWorkflow(message);
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
            var workflow = GetWorkflow(message);
            var worker = workflow.GetFirst();
            broker.Send(worker, message);
        }

        private Workflow GetWorkflow(Message message)
        {
            return routes.First(route => route.Matches(message)).Workflow;
        }
    }
}
