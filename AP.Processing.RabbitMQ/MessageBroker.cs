using AP.Processing.Workflows;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AP.Processing.RabbitMQ
{
    public class MessageBroker : IMessageBroker
    {
        private Dictionary<string, IWorkflow> routes;

        public MessageBroker(
            BusinessWorkflow business,
            CdmRequestWorkflow cdmRequest,
            CdmSyncWorkflow cdmSync,
            CdmVersionWorkflow cdmVersion,
            IrRequestWorkflow irRequest,
            IrSyncWorkflow irSync)
        {
            routes = new Dictionary<string, IWorkflow>
            {
                { "business", business },
                { "cdmrequest", cdmRequest },
                { "cdmsync", cdmSync },
                { "cdmversion", cdmVersion },
                { "irrequest", irRequest },
                { "irsync", irSync }
            };
        }

        public void Send(Message message)
        {
            Task.Run(() => 
            {
                var workflow = routes[message.Content];
                workflow.Start(message);
            });
        }

        public void Send(WorkerInput input, IWorker worker, IWorkflow workflow)
        {
            worker.Process(input, workflow);
        }
    }
}
