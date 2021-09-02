using AP.Processing;
using AP.Processing.RabbitMQ;
using AP.Receiver.WebApi;
using System;

namespace AP.ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var store = new Store())
            using (var broker = store.Get<MessageBroker>())
            {
                broker.Connect();
                Context.MessageBroker = broker;

                var server = store.Get<Server>();
                using (server.Start("http://localhost:9000"))
                {
                    Console.WriteLine("Press [enter] to stop");
                    Console.ReadLine();
                }
            }
        }
    }
}
