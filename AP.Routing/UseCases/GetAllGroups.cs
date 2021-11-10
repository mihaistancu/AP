using System.Collections.Generic;

namespace AP.Routing.UseCases
{
    public class GetAllGroups
    {
        private RoutingRuleStorage storage;

        public GetAllGroups(RoutingRuleStorage storage)
        {
            this.storage = storage;
        }

        public IEnumerable<Group> GetAll()
        {
            return storage.GetAllGroups();
        }
    }
}
