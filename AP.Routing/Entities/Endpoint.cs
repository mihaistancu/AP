using AP.Routing.Entities.BusinessMessageRules;

namespace AP.Routing.Entities
{
    public class Endpoint
    {
        public string Name { get; set; }
        public string Type { get; set; }
        public string Url { get; set; }
        public IBusinessMessageRule BusinessMessageRule { get; set; }
    }
}
