using AP.Http;
using AP.Routing;
using AP.Routing.UseCases;
using Newtonsoft.Json.Linq;
using System.Linq;

namespace AP.Web.Api.Routing
{
    public class GetAllRoutingRulesApi
    {
        private GetAllRoutingRules useCase;

        public GetAllRoutingRulesApi(GetAllRoutingRules useCase)
        {
            this.useCase = useCase;
        }

        public void Handle(IHttpInput input, IHttpOutput output)
        {
            var rules = useCase.GetAll();
            var json = GetResult(rules);
            output.Status(200);
            Json.Write(json, output);
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
