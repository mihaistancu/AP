using AP.Gateways.Institution;
using AP.Processing;
using AP.Processing.Async.Synchronization;

namespace AP.Gateways.CSN
{
    public class CsnGateway : IGateway
    {
        private ICsnConfig config;
        private IMessagingClient client;

        public CsnGateway(ICsnConfig config, IMessagingClient client)
        {
            this.config = config;
            this.client = client;
        }

        public void Deliver(Message message)
        {
            var url = config.GetCsnUrl();
            client.Send(url, message);
        }
    }
}
