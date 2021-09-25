namespace AP.Processing.Async.Synchronization.IR.Subscriptions
{
    public interface IIrPublisher
    {
        void Publish(Message message);
    }
}
