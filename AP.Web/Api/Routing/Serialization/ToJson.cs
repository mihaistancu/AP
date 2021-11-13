using AP.Routing;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using System.Linq;

namespace AP.Web.Api.Routing.Serialization
{
    public class ToJson
    {
        public static JArray Map(List<Group> groups)
        {
            return new JArray(groups.Select(Map));
        }

        public static JObject Map(Group group)
        {
            return new JObject(
                new JProperty("groupId", group.GroupId),
                new JProperty("institutionIds",
                    new JArray(group.InstitutionIds)),
                new JProperty("rules",
                    new JArray(group.Rules.Select(Map))));
        }

        private static JObject Map(Rule rule)
        {
            return new JObject(
                new JProperty("name", rule.Name),
                new JProperty("type", rule.Type),
                new JProperty("url", rule.Url),
                new JProperty("condition", rule.Condition));
        }
    }
}
