using AP.Configuration.Server;
using AP.Messaging.Server;
using AP.Monitoring;

namespace AP.Host.Console
{
    class Program
    {
        static void Main(string[] args)
        {
            var store = new Store();

            store.Get<MonitoringRabbitMqOrchestrator>().Start();
            store.Get<MessagingServer>().Start();
            store.Get<ConfigurationServer>().Start();

            System.Console.WriteLine("Press [enter] to stop");
            System.Console.ReadLine();
        }
    }
}
