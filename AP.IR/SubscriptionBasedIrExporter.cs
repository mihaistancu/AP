using AP.Processing;
using AP.Processing.Async.IR.Subscriptions;

namespace AP.IR
{
    public class SubscriptionBasedIrExporter : ISubscriptionBasedIrExporter
    {
        public Message[] Export()
        {
            return new[]
            {
                new Message
                {
                    DocumentType = "SYN001",
                    Direction = Direction.Out
                },
                new Message
                {
                    DocumentType = "SYN001",
                    Direction = Direction.Out
                }
            };
        }
    }
}
