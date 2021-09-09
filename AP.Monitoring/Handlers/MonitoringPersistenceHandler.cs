using AP.Data;
using AP.Processing.Sync.Handlers.Persistence;

namespace AP.Monitoring.Handlers
{
    public class MonitoringPersistenceHandler : PersistenceHandler
    {
        public MonitoringPersistenceHandler(IMessageStorage storage) : base(storage)
        {
        }

        public override bool Handle(Message message)
        {
            System.Console.WriteLine("Persistence");
            return base.Handle(message);
        }
    }
}
