using AP.Monitoring;
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
                
                using (server.Start("http://localhost:9000"))
                {
                    System.Console.WriteLine("Press [enter] to stop");
                    System.Console.ReadLine();
                }
            }
        }
    }
}
