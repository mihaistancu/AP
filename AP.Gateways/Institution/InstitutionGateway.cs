using AP.Processing;
using AP.Processing.Async.Synchronization;
using AP.Routing;

namespace AP.Gateways.Institution
{
    public class InstitutionGateway : IGateway
    {
        private IRoutingConfig config;
        private IMessagingClient webClient;
        private IQueue queue;

        public InstitutionGateway(
            IRoutingConfig config,
            IMessagingClient webClient,
            IQueue queue)
        {
            this.config = config;
            this.webClient = webClient;
            this.queue = queue;
        }

        public void Deliver(Message message)
        {
            var endpointId = config.GetEndpoint(message);

            if (config.IsPushEndpoint(endpointId))
            {
                var url = config.GetUrl(endpointId);
                webClient.Send(url, message);
            }
            else
            {
                var channel = config.GetChannel(endpointId);
                queue.Enqueue(channel, message);
            }
        }
    }
}
