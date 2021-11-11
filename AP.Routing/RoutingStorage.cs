using System.Collections.Generic;

namespace AP.Routing
{
    public class RoutingStorage
    {
        public List<Group> groups = new List<Group>();

        public RoutingStorage()
        {
            groups.Add(new Group
            {
                GroupId = "1",
                InstitutionIds = new List<string> { "a", "b" },
                PushRules = new List<Rule>
                {
                    new Rule
                    {
                         Name = "r1",
                         Url = "https://r1"
                    },
                },
                PullRules = new List<Rule>
                {
                    new Rule
                    {
                        Name = "r2",
                        Url = "https://ap/r2"
                    }
                }
            });

            groups.Add(new Group
            {
                GroupId = "2",
                InstitutionIds = new List<string> { "x", "y", "z" },
                PushRules = new List<Rule>
                {
                    new Rule
                    {
                         Name = "r3",
                         Url = "https://r3",
                         Condition = "SED = P_BUC_01"
                    },
                    new Rule
                    {
                        Name = "r4",
                        Url = "https://r4",
                        Condition = "SED = P_BUC_02"
                    }
                },
                PullRules = new List<Rule>()
            });

            groups.Add(new Group
            {
                GroupId = "3",
                InstitutionIds = new List<string> { "m", "n" },
                PushRules = new List<Rule>(),
                PullRules = new List<Rule>
                {
                    new Rule
                    {
                        Name = "r5",
                        Url = "https://ap/r5",
                        Condition = "SED = P_BUC_03"
                    }
                }
            });
        }

        public List<Group> GetAll()
        {
            return groups;
        }

        public void DeleteGroup(string groupId)
        {
            var group = groups.Find(g => g.GroupId == groupId);
            groups.Remove(group);
        }
    }
}
