namespace AP.Routing.UseCases
{
    public class DeleteGroup
    {
        private RoutingStorage storage;

        public DeleteGroup(RoutingStorage storage)
        {
            this.storage = storage;
        }

        public void Delete(string groupId)
        {
            storage.DeleteGroup(groupId);
        }
    }
}
