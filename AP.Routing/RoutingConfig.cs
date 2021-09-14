using AP.Processing;
using AP.Processing.Async.Forwarding;

namespace AP.Routing
{
    public class RoutingConfig : IRoutingConfig
    {
        public string GetEndpoint(Message message)
        {
            return string.Empty;
        }
    }
}
