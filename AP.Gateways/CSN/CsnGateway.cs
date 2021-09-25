using AP.Gateways.Institution;
using AP.Messages;
using AP.Workers;

namespace AP.Gateways.CSN
{
    public class CsnGateway : IGateway
    {
        private ICsnConfig config;
        private IMessageClient client;

        public CsnGateway(ICsnConfig config, IMessageClient client)
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
