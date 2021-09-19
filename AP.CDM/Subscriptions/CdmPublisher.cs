using AP.Processing;
using AP.Processing.Async.Synchronization;
using AP.Processing.Async.Synchronization.CDM.Subscriptions;

namespace AP.CDM
{
    public class CdmPublisher<T> : ICdmPublisher where T: IGateway
    {
        private CdmSubscriptionStorage subscriptionStorage;
        private CdmStorage cdmStorage;
        private IMessageStorage messageStorage;
        private T gateway;

        public CdmPublisher(
            CdmSubscriptionStorage subscriptionStorage,
            CdmStorage cdmStorage,
            IMessageStorage messageStorage,
            T gateway)
        {
            this.subscriptionStorage = subscriptionStorage;
            this.cdmStorage = cdmStorage;
            this.messageStorage = messageStorage;
            this.gateway = gateway;
        }

        public void Publish(Message message)
        {
            var subscriptions = subscriptionStorage.Get();

            foreach (var subscription in subscriptions)
            {
                var messages = cdmStorage.Get(subscription);
                messageStorage.Save(messages);
                foreach (var newMessage in messages)
                {
                    gateway.Deliver(newMessage);
                }
            }
        }
    }
}
