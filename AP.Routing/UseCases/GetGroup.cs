namespace AP.Routing.UseCases
{
    public class GetGroup
    {
        private RoutingStorage storage;

        public GetGroup(RoutingStorage storage)
        {
            this.storage = storage;
        }

        public Group Get(string id)
        {
            return storage.GetGroup(id);
        }
    }
}
