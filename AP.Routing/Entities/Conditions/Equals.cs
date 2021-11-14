namespace AP.Routing.Entities.Conditions
{
    public class Equals : ICondition
    {
        public string Subject { get; set; }
        public string ExpectedValue { get; set; }
    }
}
