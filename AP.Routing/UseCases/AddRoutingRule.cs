namespace AP.Routing.UseCases
{
    public class AddRoutingRule
    {
        private RoutingRuleStorage storage;

        public AddRoutingRule(RoutingRuleStorage storage)
        {
            this.storage = storage;
        }

        public RoutingRule Add(RoutingRule rule)
        {
            return storage.Add(rule);
        }
    }
}
