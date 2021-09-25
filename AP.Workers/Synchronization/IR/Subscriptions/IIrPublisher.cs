using AP.Messages;

namespace AP.Workers.Synchronization.IR.Subscriptions
{
    public interface IIrPublisher
    {
        void Publish(Message message);
    }
}
