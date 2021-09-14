using AP.Processing.Async.CDM.Subscriptions;

namespace AP.Processing.Async.CDM.Export
{
    public class CdmSubscriptionsWorker : IWorker
    {
        private ICdmPublisher publisher;
        
        public CdmSubscriptionsWorker(ICdmPublisher publisher)
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
