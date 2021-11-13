using System;

namespace AP.Routing.UseCases
{
    public class CreateGroup
    {
        private RoutingStorage storage;

        public CreateGroup(RoutingStorage storage)
        {
            this.storage = storage;
        }

        public Group Create(Group group)
        {
            group.GroupId = Guid.NewGuid().ToString();
            storage.Add(group);
            return group;
        }


    }
}
