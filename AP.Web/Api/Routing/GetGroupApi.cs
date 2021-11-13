using AP.Http;
using AP.Routing.UseCases;
using AP.Web.Api.Routing.Serialization;

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
            var json = ToJson.Map(group);
            output.Status(200);
            Json.Write(json, output);
        }
    }
}
