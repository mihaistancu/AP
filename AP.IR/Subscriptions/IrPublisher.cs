using AP.Gateways.Institution;
using AP.Messaging;
using AP.Workers.Synchronization.IR.Subscriptions;

namespace AP.IR.Subscriptions
{
    public class IrPublisher : IIrPublisher
    { 
        private IrSubscriptionStorage irSubscriptionStorage;
        private IrStorage irStorage;
        private IMessageStorage messageStorage;
        private InstitutionGateway gateway;

        public IrPublisher(
            IrSubscriptionStorage irSubscriptionStorage,
            IrStorage irStorage,
            IMessageStorage messageStorage,
            InstitutionGateway gateway)
        {
            this.irSubscriptionStorage = irSubscriptionStorage;
            this.irStorage = irStorage;
            this.messageStorage = messageStorage;
            this.gateway = gateway;
        }

        public void Publish(Message message)
        {
            var subscriptions = irSubscriptionStorage.Get();

            foreach (var subscription in subscriptions)
            {
                var newMessage = irStorage.Get(subscription);
                messageStorage.Save(newMessage);
                gateway.Deliver(newMessage);
            }
        }
    }
}
