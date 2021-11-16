using AP.Routing.Entities;
using AP.Routing.Entities.BusinessMessageRules;
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
                Endpoints = json["endpoints"].Select(GetEndpoint).ToList()
            };
        }

        public static Endpoint GetEndpoint(JToken json)
        {
            return new Endpoint
            {
                Name = json.Value<string>("name"),
                Type = json.Value<string>("type"),
                Url = json.Value<string>("type") == "push"
                    ? json.Value<string>("url")
                    : null,
                BusinessMessageRule = json["businessMessageRule"] != null
                    ? GetBusinessMessageRule(json["businessMessageRule"])
                    : null
            };
        }

        public static IBusinessMessageRule GetBusinessMessageRule(JToken json)
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
                    Children = json["children"].Select(GetBusinessMessageRule).ToList()
                };
                case "all": return new All
                {
                    Children = json["children"].Select(GetBusinessMessageRule).ToList()
                };
            }
            throw new Exception("Cannot deserialize business message rule from JSON");
        }
    }
}
