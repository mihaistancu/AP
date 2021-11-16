using AP.Routing.Entities;
using System.Collections.Generic;

namespace AP.Routing
{
    public class RoutingStorage
    {
        public List<Group> groups = new List<Group>();

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
