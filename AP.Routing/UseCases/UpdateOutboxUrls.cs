using AP.Routing.Entities;

namespace AP.Routing.UseCases
{
    public class UpdateOutboxUrls
    {
        public void Update(Group group)
        {
            foreach (var endpoint in group.Endpoints)
            {   
                endpoint.OutboxUrl = $"https://ap/outbox/{endpoint.Name}";
            }
        }
    }
}
