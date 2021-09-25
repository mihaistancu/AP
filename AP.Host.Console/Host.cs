using AP.Configuration.API;
using AP.Messaging.Service;
using AP.Monitoring;
using AP.Processing.Async;
using AP.Storage;

namespace AP.Host.Console
{
    public class Host
    {
        public Orchestrator Orchestrator { get; private set; }
        public MessageServer MessageServer { get; private set; }
        public ConfigurationServer ConfigurationServer { get; private set; }

        public void RegisterDependencies()
        {
            var messageStorage = new MessageStorage();
            var messageClient = new MonitoredMessageClient();
            var messageQueue = new MonitoredMessageQueue();

            var orchestratorFactory = new OrchestratorFactory(messageClient, messageQueue, messageStorage);
            Orchestrator = orchestratorFactory.Get();

            var messageServerFactory = new MessageServerFactory(Orchestrator, messageStorage, messageQueue);
            MessageServer = messageServerFactory.Get();

            var configurationServerFactory = new ConfigurationServerFactory();
            ConfigurationServer = configurationServerFactory.Get();
        }
    }
}
