using AP.Http;
using AP.Routing.UseCases;
using Newtonsoft.Json.Linq;

namespace AP.Web.Api.Routing
{
    public class CreateGroupWithInstitutionApi
    {
        private CreateGroupWithInstitution useCase;

        public CreateGroupWithInstitutionApi(CreateGroupWithInstitution useCase)
        {
            this.useCase = useCase;
        }

        public void Handle(IHttpInput input, IHttpOutput output)
        {
            var institutionId = GetInstitutionId(input);
            var groupId = useCase.CreateGroupWith(institutionId);
            var json = GetResult(groupId);
            output.Status(201);
            Json.Write(json, output);
        }

        private string GetInstitutionId(IHttpInput input)
        {
            var json = Json.Read(input);
            return json.Value<string>("institutionId");
        }

        private JObject GetResult(string group)
        {
            return new JObject(
                    new JProperty("groupId", group));
        }
    }
}
