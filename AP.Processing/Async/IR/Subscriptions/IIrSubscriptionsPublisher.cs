namespace AP.Processing.Async.IR.Subscriptions
{
    public interface IIrSubscriptionsPublisher
    {
        void Publish(Message message);
    }
}
