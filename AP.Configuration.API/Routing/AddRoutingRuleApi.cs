using AP.Routing;
using AP.Web.Server;
using Newtonsoft.Json.Linq;

namespace AP.Configuration.API.Routing
{
    public class AddRoutingRuleApi : JsonApi, IWebService
    {
        private RoutingRuleStorage storage;

        public AddRoutingRuleApi(RoutingRuleStorage storage)
        {
            this.storage = storage;
        }

        public void Handle(IWebInput input, IWebOutput output)
        {
            var rule = GetRule(input);
            rule = storage.Add(rule);
            output.Status(201);
            var json = GetResult(rule);
            WriteJson(json, output);
        }

        private RoutingRule GetRule(IWebInput input)
        {
            var json = ReadJson(input);

            return new RoutingRule
            {
                Address = json.Value<string>("address")
            };
        }

        private JObject GetResult(RoutingRule rule)
        {
            return new JObject(
                    new JProperty("id", rule.Id),
                    new JProperty("address", rule.Address));
        }
    }
}
