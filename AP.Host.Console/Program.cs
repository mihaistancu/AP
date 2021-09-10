using AP.Service.WebApi;
using AP.Middleware.RabbitMQ;

namespace AP.Host.Console
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var store = new Store())
            using (var broker = store.Get<RabbitMqMessageBroker>())
            {
                broker.Connect();

                var server = store.Get<Server>();
                using (server.Start())
                {
                    System.Console.WriteLine("Press [enter] to stop");
                    System.Console.ReadLine();
                }
            }
        }
    }
}
