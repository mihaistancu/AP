using AP.Routing.Entities;

namespace AP.Routing.UseCases
{
    public class UpdateInboxUrls
    {
        public void Update(Group group)
        {
            foreach (var endpoint in group.Endpoints)
            {
                if (endpoint.Type == "pull")
                {
                    endpoint.InboxUrl = $"https://ap/inbox/{endpoint.Name}";
                }
            }
        }
    }
}
