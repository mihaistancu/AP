using AP.Processing;
using AP.Processing.RabbitMQ;
using AP.Receiver.WebApi;
using System;
using Unity;

namespace AP.ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            var container = new UnityContainer();
            var broker = container.Resolve<MessageBroker>();
            broker.Connect();
            Context.MessageBroker = broker;

            var server = container.Resolve<Server>();
            
            using (server.Start())
            {
                Console.WriteLine("Press [enter] to stop");
                Console.ReadLine();
            }
        }
    }
}
