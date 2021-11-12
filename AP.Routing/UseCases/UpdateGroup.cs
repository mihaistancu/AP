namespace AP.Routing.UseCases
{
    public class UpdateGroup
    {
        private RoutingStorage storage;

        public UpdateGroup(RoutingStorage storage)
        {
            this.storage = storage;
        }

        public void Update(Group group)
        {
            UpdatePullUrls(group);
            storage.Update(group);
        }

        private void UpdatePullUrls(Group group)
        {
            foreach (var rule in group.Rules)
            {
                if (rule.Type == "pull")
                {
                    rule.Url = $"https://ap/{rule.Name}";
                }
            }
        }
    }
}
