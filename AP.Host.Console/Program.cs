using AP.Monitoring;
using AP.Portal.WebApi;
using AP.Server;

namespace AP.Host.Console
{
    class Program
    {
        static void Main(string[] args)
        {
            var store = new Store();
            store.Get<MonitoringRabbitMqOrchestrator>().Connect();
            store.Get<MonitoringWebServer<MessagingService>>().Start("http://localhost:9000");
            store.Get<ApiServer>().Start("http://localhost:9090");

            System.Console.WriteLine("Press [enter] to stop");
            System.Console.ReadLine();
        }
    }
}
