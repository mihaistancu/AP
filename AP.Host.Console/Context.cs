using AP.Configuration.API;
using AP.Messaging.Client;
using AP.Messaging.Queue;
using AP.Messaging.Service;
using AP.Monitoring;
using AP.Orchestration;
using AP.Storage;

namespace AP.Host.Console
{
    public class Context
    {
        public static MessageStorage MessageStorage { get; set; }
        public static Orchestrator Orchestrator { get; set; }
        public static MessageClient MessageClient { get; set; }
        public static MessageQueue MessageQueue { get; set; }
        public static MessageServer MessageServer { get; set; }
        public static ConfigurationServer ConfigurationServer { get; set; }

        public static void Build()
        {
            MessageStorage = new MessageStorage();
            MessageClient = new MonitoredMessageClient();
            MessageQueue = new MonitoredMessageQueue();
            Orchestrator = OrchestratorFactory.Get();
            MessageServer = MessageServerFactory.Get();
            ConfigurationServer = ConfigurationServerFactory.Get();
        }
    }
}
