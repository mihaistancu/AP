namespace AP.Routing.UseCases
{
    public class GetAllRoutingRules
    {
        private RoutingRuleStorage storage;

        public GetAllRoutingRules(RoutingRuleStorage storage)
        {
            this.storage = storage;
        }

        public RoutingRule[] GetAll()
        {
            return storage.GetAll();
        }
    }
}
