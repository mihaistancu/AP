using System;
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
                Rules = new List<Rule>
                {
                    new Rule
                    {
                         Name = "r1",
                         Type = "push",
                         Url = "https://r1"
                    },
                    new Rule
                    {
                        Name = "r2",
                        Type = "pull",
                        Url = "https://ap/r2"
                    }
                }
            });

            groups.Add(new Group
            {
                GroupId = "2",
                InstitutionIds = new List<string> { "x", "y", "z" },
                Rules = new List<Rule>
                {
                    new Rule
                    {
                         Name = "r3",
                         Type = "push",
                         Url = "https://r3",
                         Condition = "SED = P_BUC_01"
                    },
                    new Rule
                    {
                        Name = "r4",
                        Type = "push",
                        Url = "https://r4",
                        Condition = "SED = P_BUC_02"
                    }
                }
            });

            groups.Add(new Group
            {
                GroupId = "3",
                InstitutionIds = new List<string> { "m", "n" },
                Rules = new List<Rule>
                {
                    new Rule
                    {
                        Name = "r5",
                        Type = "pull",
                        Url = "https://ap/r5",
                        Condition = "SED = P_BUC_03"
                    }
                }
            });
        }

        public void Update(Group group)
        {
            DeleteGroup(group.GroupId);
            groups.Add(group);
        }

        public Group GetGroup(string groupId)
        {
            return groups.Find(g => g.GroupId == groupId);
        }

        public List<Group> GetAll()
        {
            return groups;
        }

        public void DeleteGroup(string groupId)
        {
            var group = GetGroup(groupId);
            groups.Remove(group);
        }
    }
}
