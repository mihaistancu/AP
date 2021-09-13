﻿using AP.Data;

namespace AP.Processing.Async.Delivery
{
    public class DeliveryWorker : IWorker
    {
        private IContentBasedRouter router;

        public DeliveryWorker(IContentBasedRouter router)
        {
            this.router = router;
        }

        public virtual bool Handle(Message message)
        {
            router.Route(message);
            return true;
        }
    }
}