using AP.Routing;
using AP.Web.Server;

namespace AP.Configuration.API.Routing
{
    public class UpdateRoutingRuleApi : JsonApi, IWebService
    {
        private RoutingRuleStorage storage;

        public UpdateRoutingRuleApi(RoutingRuleStorage storage)
        {
            this.storage = storage;
        }

        public void Handle(IWebInput input, IWebOutput output)
        {
            var id = input.Get("id");
            var rule = GetRule(input);
            storage.Update(id, rule);
            output.Status(204);
        }

        private RoutingRule GetRule(IWebInput input)
        {
            var json = ReadJson(input);

            return new RoutingRule
            {
                Address = json.Value<string>("address")
            };
        }
    }
}
