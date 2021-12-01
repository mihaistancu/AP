using AP.Routing.Entities;

namespace AP.Routing.UseCases
{
    public class UpdateGroup
    {
        private RoutingStorage storage;
        private UpdateInboxUrls updateInboxUrls;
        private UpdateOutboxUrls updateOutboxUrls;

        public UpdateGroup(
            RoutingStorage storage, 
            UpdateInboxUrls updateInboxUrls,
            UpdateOutboxUrls updateOutboxUrls)
        {
            this.storage = storage;
            this.updateInboxUrls = updateInboxUrls;
            this.updateOutboxUrls = updateOutboxUrls;
        }

        public void Update(Group group)
        {
            updateInboxUrls.Update(group);
            updateOutboxUrls.Update(group);
            storage.Update(group);
        }
    }
}
