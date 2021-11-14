using AP.Routing.Entities.Conditions;

namespace AP.Routing.Entities
{
    public class Rule
    {
        public string Name { get; set; }
        public string Type { get; set; }
        public string Url { get; set; }
        public ICondition Condition { get; set; }
    }
}
