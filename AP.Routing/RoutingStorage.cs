using AP.Routing.Entities;
using AP.Routing.Entities.BusinessMessageRules;
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
                Endpoints = new List<Endpoint>
                {
                    new Endpoint
                    {
                         Name = "r1",
                         Type = "push",
                         Url = "https://r1"
                    },
                    new Endpoint
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
                Endpoints = new List<Endpoint>
                {
                    new Endpoint
                    {
                         Name = "r3",
                         Type = "push",
                         Url = "https://r3",
                         BusinessMessageRule = new Any
                         {
                             Children = new List<IBusinessMessageRule>
                             {
                                 new Equals
                                 {
                                    Subject = "SED",
                                    ExpectedValue = "P_BUC_01"
                                 },
                                 new Matches
                                 {
                                     Subject = "SED",
                                     ExpectedPattern = "regex1"
                                 },
                                 new All
                                 {
                                     Children = new List<IBusinessMessageRule>
                                     {
                                         new Equals
                                         {
                                            Subject = "SED",
                                            ExpectedValue = "P_BUC_02"
                                         },
                                         new Matches
                                         {
                                             Subject = "SED",
                                             ExpectedPattern = "regex2"
                                         },
                                         new Any
                                         {
                                             Children = new List<IBusinessMessageRule>
                                             {
                                                 new Equals
                                                 {
                                                    Subject = "SED",
                                                    ExpectedValue = "P_BUC_03"
                                                 },
                                                 new Matches
                                                 {
                                                     Subject = "SED",
                                                     ExpectedPattern = "regex3"
                                                 }
                                             }
                                         }
                                     }
                                 }
                             }
                             
                         }
                    },
                    new Endpoint
                    {
                        Name = "r4",
                        Type = "push",
                        Url = "https://r4",
                        BusinessMessageRule  = new Equals
                        {
                            Subject = "SED",
                            ExpectedValue = "P_BUC_02"
                        }
                    }
                }
            });

            groups.Add(new Group
            {
                GroupId = "3",
                InstitutionIds = new List<string> { "m", "n" },
                Endpoints = new List<Endpoint>
                {
                    new Endpoint
                    {
                        Name = "r5",
                        Type = "pull",
                        Url = "https://ap/r5",
                        BusinessMessageRule = new Equals
                        {
                            Subject = "SED",
                            ExpectedValue = "P_BUC_03"
                        }
                    }
                }
            });
        }

        public void Add(Group group)
        {
            groups.Add(group);
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
