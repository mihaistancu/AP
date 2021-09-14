namespace AP.Processing.Async.CDM.Subscriptions
{
    public interface ICdmPublisher
    {
        void Publish(Message message);
    }
}
