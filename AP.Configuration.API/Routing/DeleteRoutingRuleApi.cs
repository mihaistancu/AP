using AP.Routing;
using AP.Web.Server.Owin;

namespace AP.Configuration.API.Routing
{
    public class DeleteRoutingRuleApi : IWebService
    {
        private RoutingRuleStorage storage;

        public DeleteRoutingRuleApi(RoutingRuleStorage storage)
        {
            this.storage = storage;
        }

        public void Handle(WebInput input, WebOutput output)
        {
            string id = input.Params("id");
            storage.Delete(id);
            output.Status(204);
        }
    }
}
