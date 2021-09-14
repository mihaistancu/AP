﻿namespace AP.Processing.Async.Forwarding
{
    public class ForwardingWorker : IWorker
    {
        private IRoutingConfig config;
        private IRouter router;

        public ForwardingWorker(IRoutingConfig config, IRouter router)
        {
            this.config = config;
            this.router = router;
        }

        public virtual bool Handle(Message message)
        {
            var endpointId = config.GetEndpoint(message);
            router.Route(endpointId, message);
            return true;
        }
    }
}