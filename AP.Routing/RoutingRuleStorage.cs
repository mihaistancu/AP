using System.Collections.Generic;
using System.Linq;

namespace AP.Routing
{
    public class RoutingRuleStorage
    {
        static int id;
        private List<RoutingRule> rules = new List<RoutingRule>();

        public RoutingRuleStorage()
        {
            rules.Add(new RoutingRule
            {
                Id = "1",
                Address = "a"
            });
        }
        public Dictionary<string, string> institutions = new Dictionary<string, string>();

        public List<Group> GetAllGroups()
        {
            var result = new Dictionary<string, Group>();

            var groups = institutions.Values.Distinct();
            foreach (var group in groups)
            {
                result[group] = new Group
                {
                    GroupId = group,
                    InstitutionIds = new List<string>()
                };
            }

            foreach (var institution in institutions)
            {
                result[institution.Value].InstitutionIds.Add(institution.Key);
            }

            return result.Values.ToList();
        }

        public void AddInstitutionToGroup(string institution, string group)
        {
            institutions[institution] = group;
        }

        public RoutingRule[] GetAll()
        {
            return rules.ToArray();
        }

        public void Delete(string id)
        {
            var rule = rules.Single(r => r.Id == id);
            rules.Remove(rule);
        }

        public RoutingRule Add(RoutingRule rule)
        {
            rule.Id = id++.ToString();
            rules.Add(rule);
            return rule;
        }

        public void Update(string id, RoutingRule rule)
        {
            var existingRule = rules.Single(r => r.Id == id);
            existingRule.Address = rule.Address;
        }
    }
}
