using AP.Processing;
using AP.Processing.Async.CDM.Subscriptions;

namespace AP.CDM
{
    public class CdmSubscriptionsPublisher : ICdmSubscriptionsPublisher
    {
        private CdmSubscriptionStorage subscriptionStorage;
        private CdmStorage cdmStorage;
        private IMessageStorage messageStorage;
        private ICdmRouter router;

        public CdmSubscriptionsPublisher(
            CdmSubscriptionStorage subscriptionStorage,
            CdmStorage cdmStorage,
            IMessageStorage messageStorage,
            ICdmRouter router)
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
                router.Route(subscription, messages);
            }
        }
    }
}
