using System.Collections.Generic;

namespace AP.Routing.UseCases
{
    public class GetAllGroups
    {
        private RoutingStorage storage;

        public GetAllGroups(RoutingStorage storage)
        {
            this.storage = storage;
        }

        public List<Group> GetAll()
        {
            return storage.GetAll();
        }
    }
}
