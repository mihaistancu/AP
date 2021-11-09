namespace AP.Routing.UseCases
{
    public class UpdateRoutingRule
    {
        private RoutingRuleStorage storage;

        public UpdateRoutingRule(RoutingRuleStorage storage)
        {
            this.storage = storage;
        }

        public void Update(string id, RoutingRule rule)
        {
            storage.Update(id, rule);
        }
    }
}
