using AP.Monitoring;
using AP.Web.Server.Owin;

namespace AP.Host.Console
{
    class Program
    {
        static void Main(string[] args)
        {
            var store = new Store();

            store.Get<MonitoringRabbitMqOrchestrator>().Start();
            store.Get<OwinWebServer>().Start("http://localhost:9000");

            System.Console.WriteLine("Press [enter] to stop");
            System.Console.ReadLine();
        }
    }
}
