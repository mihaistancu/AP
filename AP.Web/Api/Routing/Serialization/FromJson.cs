using AP.Routing;
using Newtonsoft.Json.Linq;
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
                Url = json.Value<string>("type") == "push" ? json.Value<string>("url") : null,
                Condition = json.Value<string>("condition")
            };
        }
    }
}
