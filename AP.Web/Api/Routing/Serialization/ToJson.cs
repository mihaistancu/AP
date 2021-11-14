using AP.Routing.Entities;
using AP.Routing.Entities.Conditions;
using Newtonsoft.Json.Linq;
using System;
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
                new JProperty("condition", Map(rule.Condition)));
        }

        private static JObject Map(ICondition condition)
        {
            if (condition == null)
            {
                return null;
            }
            else if (condition is Any any)
            {
                return new JObject(
                    new JProperty("type", "any"),
                    new JProperty("children", new JArray(any.Children.Select(Map))));
            }
            else if (condition is All all)
            {
                return new JObject(
                    new JProperty("type", "all"),
                    new JProperty("children", new JArray(all.Children.Select(Map))));
            }
            else if (condition is Equals equals)
            {
                return new JObject(
                    new JProperty("type", "equals"),
                    new JProperty("key", equals.Subject),
                    new JProperty("value", equals.ExpectedValue));
            }
            else if (condition is Matches matches)
            {
                return new JObject(
                    new JProperty("type", "matches"),
                    new JProperty("key", matches.Subject),
                    new JProperty("value", matches.ExpectedPattern));
            }
            throw new Exception("Cannot serialize condition to JSON");
        }
    }
}
