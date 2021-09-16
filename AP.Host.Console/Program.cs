using AP.Monitoring;
using AP.Portal.WebApi;
using AP.Server;

namespace AP.Host.Console
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var store = new Store())
            using (var broker = store.Get<MonitoringRabbitMqOrchestrator>())
            {
                broker.Connect();

                var server = store.Get<MonitoringWebServer<MessagingService>>();
                var api = store.Get<ApiServer>();

                using (server.Start("http://localhost:9000"))
                using (api.Start("http://localhost:9090"))
                {
                    System.Console.WriteLine("Press [enter] to stop");
                    System.Console.ReadLine();
                }
            }
        }
    }
}
