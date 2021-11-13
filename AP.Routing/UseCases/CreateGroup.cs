using System;

namespace AP.Routing.UseCases
{
    public class CreateGroup
    {
        private RoutingStorage storage;
        private UpdatePullRules updatePullRules;

        public CreateGroup(RoutingStorage storage, UpdatePullRules updatePullRules)
        {
            this.storage = storage;
            this.updatePullRules = updatePullRules;
        }

        public Group Create(Group group)
        {
            group.GroupId = Guid.NewGuid().ToString();
            updatePullRules.Update(group);
            storage.Add(group);
            return group;
        }
    }
}
