using AP.Processing;
using AP.Processing.Async.Synchronization;

namespace AP.Gateways.Institution
{
    public class InstitutionGateway : IGateway
    {
        private IRoutingConfig config;
        private IMessageClient client;
        private IMessageQueue queue;

        public InstitutionGateway(
            IRoutingConfig config,
            IMessageClient client,
            IMessageQueue queue)
        {
            this.config = config;
            this.client = client;
            this.queue = queue;
        }

        public void Deliver(Message message)
        {
            var endpointId = config.GetEndpoint(message);

            if (config.IsPushEndpoint(endpointId))
            {
                var url = config.GetUrl(endpointId);
                client.Send(url, message);
            }
            else
            {
                var channel = config.GetChannel(endpointId);
                queue.Enqueue(channel, message);
            }
        }
    }
}
