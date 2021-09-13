using AP.Data;

namespace AP.Processing.Async.IR.Subscriptions
{
    public interface ISubscriptionBasedIrExporter
    {
        Message[] Export();
    }
}
