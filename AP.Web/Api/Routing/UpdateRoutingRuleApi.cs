using AP.Http;
using AP.Routing;
using AP.Routing.UseCases;

namespace AP.Web.Api.Routing
{
    public class UpdateRoutingRuleApi
    {
        private UpdateRoutingRule useCase;

        public UpdateRoutingRuleApi(UpdateRoutingRule useCase)
        {
            this.useCase = useCase;
        }

        public void Handle(IHttpInput input, IHttpOutput output)
        {
            var id = input.Get("id");
            var rule = GetRule(input);
            useCase.Update(id, rule);
            output.Status(204);
        }

        private RoutingRule GetRule(IHttpInput input)
        {
            var json = Json.Read(input);

            return new RoutingRule
            {
                Address = json.Value<string>("address")
            };
        }
    }
}
