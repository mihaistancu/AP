using AP.Routing;
using AP.Web.Server.Owin;
using Newtonsoft.Json.Linq;
using System.Linq;

namespace AP.Configuration.API.Routing
{
    public class GetAllRoutingRulesApi : JsonApi, IWebService
    {
        private RoutingRuleStorage storage;

        public GetAllRoutingRulesApi(RoutingRuleStorage storage)
        {
            this.storage = storage;
        }

        public void Handle(WebInput input, WebOutput output)
        {
            var rules = storage.GetAll();
            var json = GetResult(rules);
            WriteJson(json, output);
        }

        private JArray GetResult(RoutingRule[] rules)
        {
            return new JArray(
                from rule in rules
                select new JObject(
                    new JProperty("id", rule.Id),
                    new JProperty("address", rule.Address)));
        }
    }
}
