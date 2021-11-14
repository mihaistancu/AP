using AP.Routing.Entities;
using AP.Routing.Entities.Conditions;
using Newtonsoft.Json.Linq;
using System;
using System.Linq;

namespace AP.Web.Api.Routing.Serialization
{
    public class FromJson
    {
        public static Group GetGroup(JObject json)
        {
            return new Group
            {
                InstitutionIds = json["institutionIds"].Values<string>().ToList(),
                Rules = json["rules"].Select(GetRule).ToList()
            };
        }

        public static Rule GetRule(JToken json)
        {
            return new Rule
            {
                Name = json.Value<string>("name"),
                Type = json.Value<string>("type"),
                Url = json.Value<string>("type") == "push"
                    ? json.Value<string>("url")
                    : null,
                Condition = json["condition"].HasValues
                    ? GetCondition(json["condition"])
                    : null
            };
        }

        public static ICondition GetCondition(JToken json)
        {
            switch (json.Value<string>("type"))
            {
                case "equals": return new Equals
                {
                    Subject = json.Value<string>("key"),
                    ExpectedValue = json.Value<string>("value")
                };
                case "matches": return new Matches
                {
                    Subject = json.Value<string>("key"),
                    ExpectedPattern = json.Value<string>("value")
                };
                case "any": return new Any
                {
                    Children = json["children"].Select(GetCondition).ToList()
                };
                case "all": return new All
                {
                    Children = json["children"].Select(GetCondition).ToList()
                };
            }
            throw new Exception("Cannot deserialize condition from JSON");
        }
    }
}
