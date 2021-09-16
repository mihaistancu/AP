using System.Collections.Generic;

namespace AP.Portal.WebApi
{
    public class RoutingRule
    {
        public string Id { get; set; }
        public List<string> Institutions { get; set; }
        public string Predicate { get; set; }
        public EndpointType EndpointType { get; set; }
        public string Address { get; set; }
    }

    public enum EndpointType
    {
        Push,
        Pull
    }
}
