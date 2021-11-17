using AP.Routing.Entities.BusinessMessageRules;
using System.Collections.Generic;

namespace AP.Routing.Entities
{
    public class Endpoint
    {
        public string Name { get; set; }
        public string Type { get; set; }
        public string Url { get; set; }
        public string AuthorizationList { get; set; }
        public IBusinessMessageRule BusinessMessageRule { get; set; }
        public List<string> SystemMessageSubscriptions { get; set; }
    }
}
