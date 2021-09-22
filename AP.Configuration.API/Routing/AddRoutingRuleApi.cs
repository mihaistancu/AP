using AP.Routing;
using AP.Web.Server.Owin;
using Newtonsoft.Json.Linq;
using System;

namespace AP.Configuration.API.Routing
{
    public class AddRoutingRuleApi : JsonApi, IWebService
    {
        private RoutingRuleStorage storage;

        public AddRoutingRuleApi(RoutingRuleStorage storage)
        {
            this.storage = storage;
        }

        public void Handle(WebInput input, WebOutput output)
        {
            var rule = GetRule(input);
            rule.Id = GetId();
            storage.Add(rule);
            output.Status(200);
            var json = GetResult(rule);
            WriteJson(json, output);
        }

        private string GetId()
        {
            return Guid.NewGuid().ToString();
        }

        private RoutingRule GetRule(WebInput input)
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
