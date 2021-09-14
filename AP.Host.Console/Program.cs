using AP.Monitoring;

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

                var server = store.Get<MonitoringWebServer>();
                using (server.Start())
                {
                    System.Console.WriteLine("Press [enter] to stop");
                    System.Console.ReadLine();
                }
            }
        }
    }
}
