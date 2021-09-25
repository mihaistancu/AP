using AP.Configuration.API;
using AP.Web.Server;

namespace AP.Configuration.Service.Routing.API
{
    public class UpdateRoutingRuleApi : JsonApi, IWebService
    {
        private IRoutingRuleStorage storage;

        public UpdateRoutingRuleApi(IRoutingRuleStorage storage)
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
