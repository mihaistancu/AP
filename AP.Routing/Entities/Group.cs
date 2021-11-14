using System.Collections.Generic;

namespace AP.Routing.Entities
{
    public class Group
    {
        public string GroupId { get; set; }
        public List<string> InstitutionIds { get; set; }
        public List<Rule> Rules { get; set; }
    }
}
