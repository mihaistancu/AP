using AP.Http;
using AP.Routing.UseCases;

namespace AP.Web.Api.Routing
{
    public class DeleteGroupApi
    {
        private DeleteGroup useCase;

        public DeleteGroupApi(DeleteGroup useCase)
        {
            this.useCase = useCase;
        }

        public void Handle(IHttpInput input, IHttpOutput output)
        {
            var groupId = input.Get("id");
            useCase.Delete(groupId);
            output.Status(204);
        }
    }
}
