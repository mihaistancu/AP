namespace AP.Processing.Async.IR.Subscriptions
{
    public class IrSubscriptionsWorker : IWorker
    {
        private IIrSubscriptionsPublisher publisher;
        
        public IrSubscriptionsWorker(IIrSubscriptionsPublisher publisher)
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
