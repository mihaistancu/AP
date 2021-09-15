using AP.Gateways.Institution;
using AP.Processing;

namespace AP.Gateways.AP
{
    public class ApGateway : IGateway
    {
        private IEncryptor encryptor;
        private IApConfig config;
        private IWebClient client;

        public ApGateway(
            IEncryptor encryptor,
            IApConfig config,
            IWebClient client)
        {
            this.config = config;
            this.encryptor = encryptor;
            this.client = client;
        }

        public void Deliver(Message message)
        {
            encryptor.Encrypt(message);
            var url = config.GetApUrl(message.Receiver);
            client.Send(url, message);
        }
    }
}
