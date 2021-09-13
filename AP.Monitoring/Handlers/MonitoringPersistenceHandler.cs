using AP.Processing;
using AP.Processing.Sync;
using AP.Processing.Sync.Persistence;

namespace AP.Monitoring.Handlers
{
    public class MonitoringPersistenceHandler : PersistenceHandler
    {
        public MonitoringPersistenceHandler(IMessageStorage storage) : base(storage)
        {
        }

        public override bool Handle(Message message, IOutput output)
        {
            System.Console.WriteLine("Persistence");
            return base.Handle(message, output);
        }
    }
}
