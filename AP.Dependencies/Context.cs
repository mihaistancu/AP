using AP.Broker;
using AP.Client;
using AP.Configuration;
using AP.Configuration.Routing.API;
using AP.Dependencies.Factories;
using AP.Endpoints;
using AP.Monitoring;
using AP.Orchestration;
using AP.Queue;
using AP.Routing;
using AP.Storage;
using AP.Web;

namespace AP.Dependencies
{
    public class Context
    {
        public static MessageStorage MessageStorage { get; set; }
        public static Orchestrator Orchestrator { get; set; }
        public static MessageClient MessageClient { get; set; }
        public static MessageQueue MessageQueue { get; set; }
        public static MessageEndpointRoutes MessageEndpoints { get; set; }
        public static ConfigurationApiRoutes ConfigurationApi { get; set; }

        public static void Build()
        {
            MessageStorage = new MessageStorage();
            MessageClient = new MonitoredMessageClient();
            MessageQueue = new MonitoredMessageQueue();
            Orchestrator = BuildOrchestrator();
            MessageEndpoints = BuildMessageEndpoints();
            ConfigurationApi = BuildConfigurationApi();
        }

        private static Orchestrator BuildOrchestrator()
        {
            return new Orchestrator(
                new OrchestratorConfig(),
                MessageStorage,
                new MessageBroker(new RabbitMqBroker()),
                new WorkerFactory());
        }

        private static MessageEndpointRoutes BuildMessageEndpoints()
        {
            return new MessageEndpointRoutes(new HandlerFactory());
        }

        private static ConfigurationApiRoutes BuildConfigurationApi()
        {
            var routingRuleStorage = new RoutingRuleStorage();

            return new ConfigurationApiRoutes(
                new GetAllRoutingRulesApi(routingRuleStorage),
                new AddRoutingRuleApi(routingRuleStorage),
                new UpdateRoutingRuleApi(routingRuleStorage),
                new DeleteRoutingRuleApi(routingRuleStorage));
        }
    }
}
