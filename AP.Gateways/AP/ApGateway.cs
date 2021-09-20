using AP.Gateways.Institution;
using AP.Processing;
using AP.Processing.Async.Synchronization;

namespace AP.Gateways.AP
{
    public class ApGateway : IGateway
    {
        private IEncryptor encryptor;
        private IApConfig config;
        private IMessagingClient client;

        public ApGateway(
            IEncryptor encryptor,
            IApConfig config,
            IMessagingClient client)
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
