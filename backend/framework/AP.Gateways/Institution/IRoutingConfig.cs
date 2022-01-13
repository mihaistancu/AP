using AP.Messages;

namespace AP.Gateways.Institution
{
    public interface IRoutingConfig
    {   
        string GetEndpoint(Message message);
        string GetUrl(string endpointId);
        string GetChannel(string endpointId);
        bool IsPushEndpoint(string endpointId);
    }
}