namespace AP.Routing.Entities.BusinessMessageRules
{
    public class Equals : IBusinessMessageRule
    {
        public string Subject { get; set; }
        public string ExpectedValue { get; set; }
    }
}
