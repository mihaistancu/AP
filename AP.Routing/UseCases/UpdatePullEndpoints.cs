using AP.Routing.Entities;

namespace AP.Routing.UseCases
{
    public class UpdatePullEndpoints
    {
        public void Update(Group group)
        {
            foreach (var endpoint in group.Endpoints)
            {
                if (endpoint.Type == "pull")
                {
                    endpoint.Url = $"https://ap/{endpoint.Name}";
                }
            }
        }
    }
}
