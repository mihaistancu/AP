using AP.Http;
using AP.Routing;
using AP.Routing.UseCases;
using System.Linq;

namespace AP.Web.Api.Routing
{
    public class UpdateGroupApi
    {
        private UpdateGroup useCase;

        public UpdateGroupApi(UpdateGroup useCase)
        {
            this.useCase = useCase;
        }

        public void Handle(IHttpInput input, IHttpOutput output)
        {
            var group = GetGroup(input);
            useCase.Update(group);
            output.Status(204);
        }

        private Group GetGroup(IHttpInput input)
        {
            var json = Json.Read(input);

            return new Group
            {
                GroupId = input.Get("id"),
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
