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
                InstitutionIds = new List<string> { "a", "b" }
            });

            groups.Add(new Group
            {
                GroupId = "2",
                InstitutionIds = new List<string> { "x", "y", "z" }
            });

            groups.Add(new Group
            {
                GroupId = "3",
                InstitutionIds = new List<string> { "m", "n" }
            });
        }

        public List<Group> GetAll()
        {
            return groups;
        }
    }
}
