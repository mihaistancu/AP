using AP.Data;

namespace AP.Processing.Async.CDM.Subscriptions
{
    public interface ISubscriptionBasedCdmExporter
    {
        Message[] Export();
    }
}
