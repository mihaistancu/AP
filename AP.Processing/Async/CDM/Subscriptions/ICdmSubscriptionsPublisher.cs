namespace AP.Processing.Async.CDM.Subscriptions
{
    public interface ICdmSubscriptionsPublisher
    {
        void Publish(Message message);
    }
}
