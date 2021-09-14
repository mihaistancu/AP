using AP.Processing;
using AP.Processing.Async.IR.Subscriptions;

namespace AP.IR.Subscriptions
{
    public class IrSubscriptionsPublisher : IIrSubscriptionsPublisher
    {
        private IrSubscriptionStorage irSubscriptionStorage;
        private IrStorage irStorage;
        private IMessageStorage messageStorage;
        private IIrRouter router;

        public IrSubscriptionsPublisher(
            IrSubscriptionStorage irSubscriptionStorage,
            IrStorage irStorage,
            IMessageStorage messageStorage,
            IIrRouter router)
        {
            this.irSubscriptionStorage = irSubscriptionStorage;
            this.irStorage = irStorage;
            this.messageStorage = messageStorage;
            this.router = router;
        }

        public void Publish(Message message)
        {
            var subscriptions = irSubscriptionStorage.Get();

            foreach (var subscription in subscriptions)
            {
                var newMessage = irStorage.Get(subscription);
                messageStorage.Save(newMessage);
                router.Route(subscription, newMessage);
            }
        }
    }
}
