using AP.Routing.Entities;

namespace AP.Routing.UseCases
{
    public class UpdateGroup
    {
        private RoutingStorage storage;
        private UpdatePullEndpoints updatePullEndpoints;

        public UpdateGroup(RoutingStorage storage, UpdatePullEndpoints updatePullEndpoints)
        {
            this.storage = storage;
            this.updatePullEndpoints = updatePullEndpoints;
        }

        public void Update(Group group)
        {
            updatePullEndpoints.Update(group);
            storage.Update(group);
        }
    }
}
