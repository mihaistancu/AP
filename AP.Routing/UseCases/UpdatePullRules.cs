namespace AP.Routing.UseCases
{
    public class UpdatePullRules
    {
        public void Update(Group group)
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
