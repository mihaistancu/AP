using AP.Routing;
using AP.Web.Server;

namespace AP.Configuration.API.Routing
{
    public class DeleteRoutingRuleApi : IWebService
    {
        private RoutingRuleStorage storage;

        public DeleteRoutingRuleApi(RoutingRuleStorage storage)
        {
            this.storage = storage;
        }

        public void Handle(IWebInput input, IWebOutput output)
        {
            string id = input.Params("id");
            storage.Delete(id);
            output.Status(204);
        }
    }
}
