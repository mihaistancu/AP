using AP.Processing;
using AP.Routing.Config;

namespace AP.Routing
{
    public class Router : IRouter
    {
        private ICsnConfig csnConfig;
        private IInstitutionConfig institutionConfig;
        private IEncryptor encryptor;
        private IWebClient client;
        private IQueue queue;
        private RoutingConfig config;

        public Router(
            ICsnConfig csnConfig, 
            IInstitutionConfig institutionConfig,
            IEncryptor encryptor,
            IWebClient client,
            IQueue queue,
            RoutingConfig config)
        {
            this.csnConfig = csnConfig;
            this.institutionConfig = institutionConfig;
            this.encryptor = encryptor;
            this.client = client;
            this.queue = queue;
            this.config = config;
        }

        public void Route(string endpointId, params Message[] messages)
        {
            if (csnConfig.IsCsn(endpointId))
            {
                var url = csnConfig.GetUrl(endpointId);
                client.Send(url, messages);
            }
            else if (institutionConfig.IsExternalInstitution(endpointId))
            {
                var url = institutionConfig.GetUrl(endpointId);
                encryptor.Encrypt(messages);
                client.Send(url, messages);
            }
            else if (config.IsPushEndpoint(endpointId))
            {
                var url = config.GetUrl(endpointId);
                client.Send(url, messages);
            }
            else
            {
                var channel = config.GetChannel(endpointId);
                queue.Enqueue(channel, messages);
            }
        }
    }
}
