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
        public static MessageEndpoints MessageEndpoints { get; set; }
        public static ApiRoutes ApiRoutes { get; set; }
        public static SpaRoutes SpaRoutes { get; set; }

        public static void Build()
        {
            MessageStorage = new MessageStorage();
            MessageClient = new MonitoredMessageClient();
            MessageQueue = new MonitoredMessageQueue();
            Orchestrator = BuildOrchestrator();
            MessageEndpoints = BuildMessageEndpoints();
            ApiRoutes = BuildApiRoutes();
            SpaRoutes = new SpaRoutes();
        }

        private static Orchestrator BuildOrchestrator()
        {
            return new Orchestrator(
                new OrchestratorConfig(),
                MessageStorage,
                new MessageBroker(new RabbitMqBroker()),
                new WorkerFactory());
        }

        private static MessageEndpoints BuildMessageEndpoints()
        {
            return new MessageEndpoints(new HandlerFactory());
        }

        private static ApiRoutes BuildApiRoutes()
        {
            var routingRuleStorage = new RoutingRuleStorage();

            return new ApiRoutes(
                new GetAllRoutingRulesApi(routingRuleStorage),
                new AddRoutingRuleApi(routingRuleStorage),
                new UpdateRoutingRuleApi(routingRuleStorage),
                new DeleteRoutingRuleApi(routingRuleStorage));
        }
    }
}
