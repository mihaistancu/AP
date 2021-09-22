using AP.Routing;
using AP.Web.Server.Owin;
using Newtonsoft.Json.Linq;
using System;
using System.IO;

namespace AP.Configuration.API.Routing
{
    public class AddRoutingRuleApi : IWebService
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
            var result = GetResult(rule);
            output.Send(result);
        }

        private string GetId()
        {
            return Guid.NewGuid().ToString();
        }

        private RoutingRule GetRule(WebInput input)
        {
            var reader = new StreamReader(input.GetBody());
            var json = reader.ReadToEnd();
            JObject rule = JObject.Parse(json);

            return new RoutingRule
            {
                Address = rule.Value<string>("address")
            };
        }

        private string GetResult(RoutingRule rule)
        {
            return new JObject(
                    new JProperty("id", rule.Id),
                    new JProperty("address", rule.Address))
                .ToString();
        }
    }
}
