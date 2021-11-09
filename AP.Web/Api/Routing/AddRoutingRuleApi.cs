using AP.Http;
using AP.Routing;
using AP.Routing.UseCases;
using Newtonsoft.Json.Linq;

namespace AP.Web.Api.Routing
{
    public class AddRoutingRuleApi
    {
        private AddRoutingRule useCase;

        public AddRoutingRuleApi(AddRoutingRule useCase)
        {
            this.useCase = useCase;
        }

        public void Handle(IHttpInput input, IHttpOutput output)
        {
            var rule = GetRule(input);
            rule = useCase.Add(rule);
            output.Status(201);
            var json = GetResult(rule);
            Json.Write(json, output);
        }

        private RoutingRule GetRule(IHttpInput input)
        {
            var json = Json.Read(input);

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
