using AP.Broker.RabbitMq;
using AP.Messaging.Client;
using AP.Messaging.Queue;
using AP.Orchestration;
using AP.Storage;

namespace AP.Host.Console
{
    public class OrchestratorFactory
    {
        private MessageClient messageClient;
        private MessageQueue messageQueue;
        private MessageStorage messageStorage;

        public OrchestratorFactory(
            MessageClient messageClient,
            MessageQueue messageQueue,
            MessageStorage messageStorage)
        {
            this.messageClient = messageClient;
            this.messageQueue = messageQueue;
            this.messageStorage = messageStorage;
        }

        public Orchestrator Get()
        {
            var workerFactory = new WorkerFactory(messageClient, messageQueue, messageStorage);

            return new Orchestrator(
                new OrchestratorConfig(), 
                messageStorage, 
                new MessageBroker(new RabbitMqBroker()), 
                workerFactory.Get);
        }
    }
}
