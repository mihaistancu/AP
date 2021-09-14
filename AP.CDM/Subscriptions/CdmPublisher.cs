using AP.Processing;
using AP.Processing.Async.CDM.Subscriptions;

namespace AP.CDM
{
    public class CdmPublisher : ICdmPublisher
    {
        private CdmSubscriptionStorage subscriptionStorage;
        private CdmStorage cdmStorage;
        private IMessageStorage messageStorage;
        private IRouter router;

        public CdmPublisher(
            CdmSubscriptionStorage subscriptionStorage,
            CdmStorage cdmStorage,
            IMessageStorage messageStorage,
            IRouter router)
        {
            this.subscriptionStorage = subscriptionStorage;
            this.cdmStorage = cdmStorage;
            this.messageStorage = messageStorage;
            this.router = router;
        }

        public void Publish(Message message)
        {
            var subscriptions = subscriptionStorage.Get();

            foreach (var subscription in subscriptions)
            {
                var messages = cdmStorage.Get(subscription);
                messageStorage.Save(messages);
                router.Route(subscription.Subscriber, messages);
            }
        }
    }
}
