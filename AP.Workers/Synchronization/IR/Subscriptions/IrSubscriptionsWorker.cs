using AP.Messaging;

namespace AP.Workers.Synchronization.IR.Subscriptions
{
    public class IrSubscriptionsWorker : IWorker
    {
        private IIrPublisher publisher;

        public IrSubscriptionsWorker(IIrPublisher publisher)
        {
            this.publisher = publisher;
        }

        public virtual bool Handle(Message message)
        {
            publisher.Publish(message);
            return true;
        }
    }
}
