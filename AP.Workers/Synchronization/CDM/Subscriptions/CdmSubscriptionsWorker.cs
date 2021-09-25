﻿using AP.Messaging;

namespace AP.Workers.Synchronization.CDM.Subscriptions
{
    public class CdmSubscriptionsWorker : IWorker
    {
        private ICdmPublisher publisher;

        public CdmSubscriptionsWorker(ICdmPublisher publisher)
        {
            this.publisher = publisher;
        }

        public virtual bool Handle(Message message)
        {
            publisher.Publish(message);
            return true;
        }
    }
}
