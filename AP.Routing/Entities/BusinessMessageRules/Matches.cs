namespace AP.Routing.Entities.BusinessMessageRules
{
    public class Matches : IBusinessMessageRule
    {
        public string Subject { get; set; }
        public string ExpectedPattern { get; set; }
    }
}
