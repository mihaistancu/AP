using AP.Gateways.CSN;
using AP.Messaging.Client;
using AP.Messaging.Queue;
using AP.Monitoring;
using AP.Processing.Async;
using AP.Processing.Async.Antimalware;
using AP.Routing;
using Unity;
using Unity.Injection;
using Unity.RegistrationByConvention;

namespace AP.Host.Console.Dependencies
{
    public class Store
    {
        UnityContainer container;

        public Store()
        {
            container = new UnityContainer();
        }

        public void RegisterDependencies()
        {
            container.RegisterTypes(
                AllClasses.FromAssembliesInBasePath(),
                WithMappings.FromMatchingInterface,
                WithName.Default);

            container.RegisterType<MessageClient, MonitoredMessageClient>();
            container.RegisterType<MessageQueue, MonitoredMessageQueue>();

            container.RegisterType<WorkerMap>(TypeLifetime.Singleton);
            container.RegisterType<RoutingRuleStorage>(TypeLifetime.Singleton);
            container.RegisterType<Orchestrator>(TypeLifetime.Singleton);
        }

        public T Get<T>()
        {
            return container.Resolve<T>();
        }
    }
}
