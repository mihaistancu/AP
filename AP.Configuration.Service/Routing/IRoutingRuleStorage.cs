namespace AP.Configuration.Routing
{
    public interface IRoutingRuleStorage
    {
        RoutingRule Add(RoutingRule rule);
        void Delete(string id);
        RoutingRule[] GetAll();
        void Update(string id, RoutingRule rule);
    }
}