﻿using AP.Processing;
using AP.Processing.Async.Forwarding;

namespace AP.Routing.Config
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