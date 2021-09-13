using AP.Data;
using AP.Processing.Async.CDM.Subscriptions;

namespace AP.CDM
{
    public class SubscriptionBasedCdmExporter : ISubscriptionBasedCdmExporter
    {
        public Message[] Export()
        {
            return new[]
            {
                new Message
                {
                    DocumentType = "SYN003",
                    Direction = Direction.Out
                },
                new Message
                {
                    DocumentType = "SYN003",
                    Direction = Direction.Out
                }
            };
        }
    }
}
