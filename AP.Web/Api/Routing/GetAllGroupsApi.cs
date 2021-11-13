using AP.Http;
using AP.Routing.UseCases;
using AP.Web.Api.Routing.Serialization;

namespace AP.Web.Api.Routing
{
    public class GetAllGroupsApi
    {
        private GetAllGroups useCase;

        public GetAllGroupsApi(GetAllGroups useCase)
        {
            this.useCase = useCase;
        }

        public void Handle(IHttpInput input, IHttpOutput output)
        {
            var groups = useCase.GetAll();
            var json = ToJson.Map(groups);
            output.Status(200);
            Json.Write(json, output);
        }
    }
}
