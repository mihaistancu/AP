﻿using AP.Configuration.API;
using AP.Web.Server;
using Newtonsoft.Json.Linq;

namespace AP.Configuration.Service.Routing.API
{
    public class AddRoutingRuleApi : JsonApi, IWebService
    {
        private IRoutingRuleStorage storage;

        public AddRoutingRuleApi(IRoutingRuleStorage storage)
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
