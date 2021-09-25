using AP.Messages;

namespace AP.Workers.Synchronization.CDM.Subscriptions
{
    public interface ICdmPublisher
    {
        void Publish(Message message);
    }
}
