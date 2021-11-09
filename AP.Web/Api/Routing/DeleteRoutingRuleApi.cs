using AP.Http;
using AP.Routing.UseCases;

namespace AP.Web.Api.Routing
{
    public class DeleteRoutingRuleApi
    {
        private DeleteRoutingRule useCase;

        public DeleteRoutingRuleApi(DeleteRoutingRule useCase)
        {
            this.useCase = useCase;
        }

        public void Handle(IHttpInput input, IHttpOutput output)
        {
            string id = input.Get("id");
            useCase.Delete(id);
            output.Status(204);
        }
    }
}
