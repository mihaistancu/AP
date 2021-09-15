using AP.Processing;
using AP.Processing.Async.IR.Subscriptions;

namespace AP.IR.Subscriptions
{
    public class IrPublisher<T> : IIrPublisher where T: IGateway
    {
        private IrSubscriptionStorage irSubscriptionStorage;
        private IrStorage irStorage;
        private IMessageStorage messageStorage;
        private T gateway;

        public IrPublisher(
            IrSubscriptionStorage irSubscriptionStorage,
            IrStorage irStorage,
            IMessageStorage messageStorage,
            T gateway)
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
