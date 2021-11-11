﻿using System.Collections.Generic;

namespace AP.Routing
{
    public class Group
    {
        public string GroupId { get; set; }
        public List<string> InstitutionIds { get; set; }
        public List<Rule> PushRules { get; set; }
        public List<Rule> PullRules { get; set; }
    }
}
