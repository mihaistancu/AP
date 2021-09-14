using AP.Processing;
using AP.Processing.Async.IR.Subscriptions;

namespace AP.IR.Subscriptions
{
    public class IrPublisher : IIrPublisher
    {
        private IrSubscriptionStorage irSubscriptionStorage;
        private IrStorage irStorage;
        private IMessageStorage messageStorage;
        private IRouter router;

        public IrPublisher(
            IrSubscriptionStorage irSubscriptionStorage,
            IrStorage irStorage,
            IMessageStorage messageStorage,
            IRouter router)
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
                router.Route(subscription.Subscriber, newMessage);
            }
        }
    }
}
