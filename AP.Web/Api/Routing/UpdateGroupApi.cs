using AP.Http;
using AP.Routing.UseCases;
using AP.Web.Api.Routing.Serialization;

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
            var json = Json.Read(input);
            var group = FromJson.GetGroup(json);
            group.GroupId = input.Get("id");
            useCase.Update(group);
            output.Status(204);
        }
    }
}
