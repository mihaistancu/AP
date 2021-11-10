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
                GroupId = "1"
            });

            groups.Add(new Group
            {
                GroupId = "2"
            });

            groups.Add(new Group
            {
                GroupId = "3"
            });
        }

        public List<Group> GetAll()
        {
            return groups;
        }
    }
}
