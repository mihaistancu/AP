using AP.Routing.Entities;
using System;

namespace AP.Routing.UseCases
{
    public class CreateGroup
    {
        private RoutingStorage storage;
        private UpdateInboxUrls updateInboxUrls;
        private UpdateOutboxUrls updateOutboxUrls;

        public CreateGroup(
            RoutingStorage storage, 
            UpdateInboxUrls updateInboxUrls,
            UpdateOutboxUrls updateOutboxUrls)
        {
            this.storage = storage;
            this.updateInboxUrls = updateInboxUrls;
            this.updateOutboxUrls = updateOutboxUrls;
        }

        public Group Create(Group group)
        {
            group.GroupId = Guid.NewGuid().ToString();
            updateInboxUrls.Update(group);
            updateOutboxUrls.Update(group);
            storage.Add(group);
            return group;
        }
    }
}
