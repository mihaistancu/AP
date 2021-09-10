using AP.Data;

namespace AP.Processing.Async.Workers.Delivery
{
    public class DeliveryWorker : IWorker
    {
        private IContentBasedRouter router;

        public DeliveryWorker(IContentBasedRouter router)
        {
            this.router = router;
        }

        public virtual void Handle(Message message)
        {
            router.Route(message);
        }
    }
}
