using AP.Http;
using AP.Routing;
using AP.Routing.UseCases;
using AP.Web.Api.Routing.Serialization;
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
            var json = ToJson.Map(group);
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
    }
}
