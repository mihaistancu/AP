using AP.Routing.Entities;
using System;

namespace AP.Routing.UseCases
{
    public class CreateGroup
    {
        private RoutingStorage storage;
        private UpdatePullEndpoints updatePullEndpoints;

        public CreateGroup(RoutingStorage storage, UpdatePullEndpoints updatePullEndpoints)
        {
            this.storage = storage;
            this.updatePullEndpoints = updatePullEndpoints;
        }

        public Group Create(Group group)
        {
            group.GroupId = Guid.NewGuid().ToString();
            updatePullEndpoints.Update(group);
            storage.Add(group);
            return group;
        }
    }
}
