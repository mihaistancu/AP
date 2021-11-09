namespace AP.Routing.UseCases
{
    public class DeleteRoutingRule
    {
        private RoutingRuleStorage storage;

        public DeleteRoutingRule(RoutingRuleStorage storage)
        {
            this.storage = storage;
        }

        public void Delete(string id)
        {
            storage.Delete(id);
        }
    }
}
