using AP.Broker;
using AP.Orchestration;

namespace AP.Dependencies.Factories
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
