using AP.Configuration.API;
using AP.Messaging.Service;
using AP.Processing.Async;

namespace AP.Host.Console
{
    class Program
    {
        static void Main(string[] args)
        {
            var store = new Store();
            store.RegisterDependencies();
            store.EnableMonitoring();

            store.Get<Orchestrator>().Start();
            store.Get<MessageServer>().Start();
            store.Get<ConfigurationServer>().Start();

            System.Console.WriteLine("Press [enter] to stop");
            System.Console.ReadLine();
        }
    }
}
