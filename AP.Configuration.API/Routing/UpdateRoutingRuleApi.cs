using AP.Routing;
using AP.Web.Server.Owin;

namespace AP.Configuration.API.Routing
{
    public class UpdateRoutingRuleApi : JsonApi, IWebService
    {
        private RoutingRuleStorage storage;

        public UpdateRoutingRuleApi(RoutingRuleStorage storage)
        {
            this.storage = storage;
        }

        public void Handle(WebInput input, WebOutput output)
        {
            var id = input.Params("id");
            var rule = GetRule(input);
            storage.Update(id, rule);
            output.Status(204);
        }

        private RoutingRule GetRule(WebInput input)
        {
            var json = ReadJson(input);

            return new RoutingRule
            {
                Address = json.Value<string>("address")
            };
        }
    }
}
