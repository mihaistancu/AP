using AP.Routing.Entities;

namespace AP.Routing.UseCases
{
    public class UpdateGroup
    {
        private RoutingStorage storage;
        private UpdatePullRules updatePullRules;

        public UpdateGroup(RoutingStorage storage, UpdatePullRules updatePullRules)
        {
            this.storage = storage;
            this.updatePullRules = updatePullRules;
        }

        public void Update(Group group)
        {
            updatePullRules.Update(group);
            storage.Update(group);
        }
    }
}
