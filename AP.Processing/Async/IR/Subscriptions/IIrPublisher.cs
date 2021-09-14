namespace AP.Processing.Async.IR.Subscriptions
{
    public interface IIrPublisher
    {
        void Publish(Message message);
    }
}
