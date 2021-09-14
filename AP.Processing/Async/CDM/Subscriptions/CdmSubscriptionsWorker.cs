using AP.Processing.Async.CDM.Subscriptions;

namespace AP.Processing.Async.CDM.Export
{
    public class CdmSubscriptionsWorker : IWorker
    {
        private ICdmSubscriptionsPublisher publisher;
        
        public CdmSubscriptionsWorker(ICdmSubscriptionsPublisher publisher)
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
