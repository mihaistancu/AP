using AP.Gateways.Institution;
using AP.Messages;

namespace AP.Routing
{
    public class RoutingConfig : IRoutingConfig
    {
        public string GetEndpoint(Message message)
        {
            return string.Empty;
        }

        public bool IsPushEndpoint(string endpointId)
        {
            return true;
        }

        public string GetUrl(string endpointId)
        {
            return string.Empty;
        }

        public string GetChannel(string endpointId)
        {
            return string.Empty;
        }
    }
}
