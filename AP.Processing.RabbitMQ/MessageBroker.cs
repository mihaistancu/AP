using AP.Processing.Workflows;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AP.Processing.RabbitMQ
{
    public class MessageBroker : IMessageBroker
    {
        private readonly WorkflowStore workflowStore;

        public MessageBroker(WorkflowStore workflowStore)
        {
            this.workflowStore = workflowStore;
        }
        
        public void Send(Message message)
        {
            Task.Run(() => 
            {
                var workflow = workflowStore.Get(message.Content);
                workflow.Start(message);
            });
        }

        public void Send(WorkerInput input, IWorker worker, IWorkflow workflow)
        {
            worker.Process(input, workflow);
        }
    }
}
