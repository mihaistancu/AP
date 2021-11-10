using AP.Http;
using AP.Routing;
using AP.Routing.UseCases;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using System.Linq;

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
            var json = GetResult(groups);
            output.Status(200);
            Json.Write(json, output);
        }

        private JArray GetResult(List<Group> groups)
        {
            return new JArray(
                from g in groups
                select new JObject(
                    new JProperty("groupId", g.GroupId)));
        }
    }
}
