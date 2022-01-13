using AP.Http;
using AP.Routing.UseCases;
using AP.Web.Api.Routing.Serialization;

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
            var json = Json.Read(input);
            var group = FromJson.GetGroup(json);
            group = useCase.Create(group);
            json = ToJson.Map(group);
            output.Status(201);
            Json.Write(json, output);
        }
    }
}
