using AP.Gateways.Institution;
using AP.Messaging;
using AP.Workers;

namespace AP.Gateways.AP
{
    public class ApGateway : IGateway
    {
        private IEncryptor encryptor;
        private IApConfig config;
        private IMessageClient client;

        public ApGateway(
            IEncryptor encryptor,
            IApConfig config,
            IMessageClient client)
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
