using AP.IO;
using Newtonsoft.Json.Linq;
using System.Linq;

namespace AP.Configuration.Routing.API
{
    public class GetAllRoutingRulesApi : JsonApi, IWebService
    {
        private IRoutingRuleStorage storage;

        public GetAllRoutingRulesApi(IRoutingRuleStorage storage)
        {
            this.storage = storage;
        }

        public void Handle(IWebInput input, IWebOutput output)
        {
            var rules = storage.GetAll();
            var json = GetResult(rules);
            output.Status(200);
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
