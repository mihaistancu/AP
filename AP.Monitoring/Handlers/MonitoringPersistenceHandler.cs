using AP.Processing.Sync.Handlers;

namespace AP.Monitoring.Handlers
{
    public class MonitoringPersistenceHandler : PersistenceHandler
    {
        public override bool Handle(Message message)
        {
            System.Console.WriteLine("Persistence");
            return base.Handle(message);
        }
    }
}
