using AP.Routing.Entities;
using AP.Routing.Entities.BusinessMessageRules;
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
                new JProperty("endpoints",
                    new JArray(group.Endpoints.Select(Map))));
        }

        private static JObject Map(Endpoint endpoint)
        {
            return endpoint.BusinessMessageRule == null
            ? new JObject(
                new JProperty("name", endpoint.Name),
                new JProperty("type", endpoint.Type),
                new JProperty("url", endpoint.Url))
            : new JObject(
                new JProperty("name", endpoint.Name),
                new JProperty("type", endpoint.Type),
                new JProperty("url", endpoint.Url),
                new JProperty("businessMessageRule", Map(endpoint.BusinessMessageRule)));
        }

        private static JObject Map(IBusinessMessageRule rule)
        {
            if (rule is Any any)
            {
                return new JObject(
                    new JProperty("type", "any"),
                    new JProperty("children", new JArray(any.Children.Select(Map))));
            }
            else if (rule is All all)
            {
                return new JObject(
                    new JProperty("type", "all"),
                    new JProperty("children", new JArray(all.Children.Select(Map))));
            }
            else if (rule is Equals equals)
            {
                return new JObject(
                    new JProperty("type", "equals"),
                    new JProperty("key", equals.Subject),
                    new JProperty("value", equals.ExpectedValue));
            }
            else if (rule is Matches matches)
            {
                return new JObject(
                    new JProperty("type", "matches"),
                    new JProperty("key", matches.Subject),
                    new JProperty("value", matches.ExpectedPattern));
            }
            throw new Exception("Cannot serialize business message rule to JSON");
        }
    }
}
