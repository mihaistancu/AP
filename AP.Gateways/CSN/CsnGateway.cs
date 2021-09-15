using AP.Gateways.Institution;
using AP.Processing;

namespace AP.Gateways.CSN
{
    public class CsnGateway : IGateway
    {
        private ICsnConfig config;
        private IWebClient client;

        public CsnGateway(ICsnConfig config, IWebClient client)
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
