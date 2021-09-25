using AP.Messaging;

namespace AP.Workers.Synchronization.IR.Subscriptions
{
    public interface IIrPublisher
    {
        void Publish(Message message);
    }
}
