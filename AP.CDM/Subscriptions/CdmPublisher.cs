using AP.Gateways.Institution;
using AP.Processing;
using AP.Processing.Async.Synchronization.CDM.Subscriptions;

namespace AP.CDM
{
    public class CdmPublisher : ICdmPublisher 
    {
        private CdmSubscriptionStorage subscriptionStorage;
        private CdmStorage cdmStorage;
        private IMessageStorage messageStorage;
        private InstitutionGateway gateway;

        public CdmPublisher(
            CdmSubscriptionStorage subscriptionStorage,
            CdmStorage cdmStorage,
            IMessageStorage messageStorage,
            InstitutionGateway gateway)
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
