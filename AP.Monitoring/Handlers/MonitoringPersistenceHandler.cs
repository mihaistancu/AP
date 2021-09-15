using AP.Processing;
using AP.Processing.Sync.Persistence;

namespace AP.Monitoring.Handlers
{
    public class MonitoringPersistenceHandler : PersistenceHandler
    {
        public MonitoringPersistenceHandler(IMessageStorage storage) : base(storage)
        {
        }

        public override (bool, Message) Handle(Message message)
        {
            System.Console.WriteLine("Persistence");
            return base.Handle(message);
        }
    }
}
