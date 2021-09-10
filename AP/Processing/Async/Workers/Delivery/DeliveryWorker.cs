using AP.Data;
using System;

namespace AP.Processing.Async.Workers.Delivery
{
    public class DeliveryWorker : IWorker
    {
        private IContentBasedRouter router;

        public DeliveryWorker(IContentBasedRouter router)
        {
            this.router = router;
        }

        public virtual Message[] Handle(Message message)
        {
            router.Route(message);

            return new[] { message };
        }
    }
}
