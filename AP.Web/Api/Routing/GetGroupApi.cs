using AP.Http;
using AP.Routing;
using AP.Routing.UseCases;
using Newtonsoft.Json.Linq;
using System.Linq;

namespace AP.Web.Api.Routing
{
    public class GetGroupApi
    {
        private GetGroup useCase;

        public GetGroupApi(GetGroup useCase)
        {
            this.useCase = useCase;
        }

        public void Handle(IHttpInput input, IHttpOutput output)
        {
            var groupId = input.Get("id");
            var group = useCase.Get(groupId);
            var json = GetResult(group);
            output.Status(200);
            Json.Write(json, output);
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
