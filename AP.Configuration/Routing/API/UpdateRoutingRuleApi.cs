using AP.Http;

namespace AP.Configuration.Routing.API
{
    public class UpdateRoutingRuleApi : JsonApi
    {
        private IRoutingRuleStorage storage;

        public UpdateRoutingRuleApi(IRoutingRuleStorage storage)
        {
            this.storage = storage;
        }

        public void Handle(IHttpInput input, IHttpOutput output)
        {
            var id = input.Get("id");
            var rule = GetRule(input);
            storage.Update(id, rule);
            output.Status(204);
        }

        private RoutingRule GetRule(IHttpInput input)
        {
            var json = ReadJson(input);

            return new RoutingRule
            {
                Address = json.Value<string>("address")
            };
        }
    }
}
