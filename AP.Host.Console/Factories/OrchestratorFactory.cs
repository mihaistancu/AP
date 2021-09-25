using AP.Broker.RabbitMq;
using AP.Orchestration;

namespace AP.Host.Console
{
    public class OrchestratorFactory
    {
        public static Orchestrator Get()
        {
            var workerFactory = new WorkerFactory();

            return new Orchestrator(
                new OrchestratorConfig(), 
                Context.MessageStorage, 
                new MessageBroker(new RabbitMqBroker()), 
                workerFactory.Get);
        }
    }
}
