using AP.Http;
using AP.Routing;
using AP.Routing.UseCases;
using Newtonsoft.Json.Linq;
using System.Linq;

namespace AP.Web.Api.Routing
{
    public class CreateGroupApi
    {
        private CreateGroup useCase;

        public CreateGroupApi(CreateGroup useCase)
        {
            this.useCase = useCase;
        }

        public void Handle(IHttpInput input, IHttpOutput output)
        {
            var group = GetGroup(input);
            group = useCase.Create(group);
            var json = GetResult(group);
            output.Status(201);
            Json.Write(json, output);
        }

        private Group GetGroup(IHttpInput input)
        {
            var json = Json.Read(input);

            return new Group
            {
                InstitutionIds = json["institutionIds"].Values<string>().ToList(),
                Rules = json["rules"]
                .Select(r => new Rule
                {
                    Name = r.Value<string>("name"),
                    Type = r.Value<string>("type"),
                    Url = r.Value<string>("type") == "push" ? r.Value<string>("url") : null,
                    Condition = r.Value<string>("condition")
                })
                .ToList()
            };
        }

        private JObject GetResult(Group group)
        {
            return new JObject(
                    new JProperty("groupId", group.GroupId),
                    new JProperty("institutionIds",
                        new JArray(group.InstitutionIds)),
                    new JProperty("rules",
                        new JArray(from r in @group.Rules
                                   select new JObject(
                                       new JProperty("name", r.Name),
                                       new JProperty("type", r.Type),
                                       new JProperty("url", r.Url),
                                       new JProperty("condition", r.Condition)))));
        }
    }
}
