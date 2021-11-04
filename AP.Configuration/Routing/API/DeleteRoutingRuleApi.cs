using AP.IO;

namespace AP.Configuration.Routing.API
{
    public class DeleteRoutingRuleApi : IHttpHandler
    {
        private IRoutingRuleStorage storage;

        public DeleteRoutingRuleApi(IRoutingRuleStorage storage)
        {
            this.storage = storage;
        }

        public void Handle(IHttpInput input, IHttpOutput output)
        {
            string id = input.Get("id");
            storage.Delete(id);
            output.Status(204);
        }
    }
}
