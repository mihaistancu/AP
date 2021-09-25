namespace AP.Processing.Async.Synchronization.CDM.Subscriptions
{
    public interface ICdmPublisher
    {
        void Publish(Message message);
    }
}
