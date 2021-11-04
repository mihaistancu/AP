using AP.Client;
using AP.Dependencies.Factories;
using AP.Monitoring;
using AP.Orchestration;
using AP.Portal;
using AP.Queue;
using AP.Server;
using AP.Storage;

namespace AP.Dependencies
{
    public class Context
    {
        public static MessageStorage MessageStorage { get; set; }
        public static Orchestrator Orchestrator { get; set; }
        public static MessageClient MessageClient { get; set; }
        public static MessageQueue MessageQueue { get; set; }
        public static MessageServer MessageServer { get; set; }
        public static PortalServer PortalServer { get; set; }

        public static void Build()
        {
            MessageStorage = new MessageStorage();
            MessageClient = new MonitoredMessageClient();
            MessageQueue = new MonitoredMessageQueue();
            Orchestrator = OrchestratorFactory.Get();
            MessageServer = MessageServerFactory.Get();
            PortalServer = PortalServerFactory.Get();
        }
    }
}
