namespace AP.Routing.Entities.Conditions
{
    public class Matches: ICondition
    {
        public string Subject { get; set; }
        public string ExpectedPattern { get; set; }
    }
}
