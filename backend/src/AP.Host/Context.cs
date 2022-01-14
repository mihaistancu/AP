using AP.Broker;
using AP.Client;
using AP.Gateways;
using AP.Ingestion;
using AP.Instrumentation;
using AP.Monitoring;
using AP.Orchestration;
using AP.Queue;
using AP.Storage;
using AP.Telemetry;
using AP.Host.Factories;

namespace AP.Host
{
    public class Context
    {
        public static IMetrics Metrics { get; set; }
        public static ILog Log { get; set; }
        public static ITrace Trace { get; set; }
        public static MessageStorage MessageStorage { get; set; }
        public static IMessageClient MessageClient { get; set; }
        public static IMessageQueue MessageQueue { get; set; }
        public static Orchestrator Orchestrator { get; set; }        
        public static IngestionService Ingestion { get; set; }

        public static void Build()
        {
            Metrics = new Metrics();
            Log = new Log();
            Trace = new Trace();
            MessageStorage = new MessageStorage();
            MessageClient = BuildMessageClient();
            MessageQueue = BuildMessageQueue();
            Orchestrator = BuildOrchestrator();   
            Ingestion = BuildIngestionService();         
        }

        private static IMessageClient BuildMessageClient()
        {
            return new MonitoredMessageClient(Trace, new MessageClient());
        }

        private static IMessageQueue BuildMessageQueue()
        {
            return new MonitoredMessageQueue(Trace, new MessageQueue());
        }

        private static Orchestrator BuildOrchestrator()
        {
            return new Orchestrator(
                new OrchestratorConfig(),
                MessageStorage,
                new MessageBroker(new MonitoredBroker(Trace, new RabbitMqBroker())),
                new WorkerFactory());
        }

        private static IngestionService BuildIngestionService()
        {
            return new IngestionService(new HandlerFactory());
        }
    }
}
