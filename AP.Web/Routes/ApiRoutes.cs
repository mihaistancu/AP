using AP.Http;

namespace AP.Web.Routes
{
    public class ApiRoutes
    {
        private HttpHandler authenticate;
        private HttpHandler getAllGroups;
        private HttpHandler deleteGroup;

        public ApiRoutes(
            HttpHandler authenticate,
            HttpHandler getAllGroups, 
            HttpHandler deleteGroup)
        {
            this.authenticate = authenticate;
            this.getAllGroups = getAllGroups;
            this.deleteGroup = deleteGroup;
        }

        public void Apply(IHttpServer server)
        {
            server.Map("POST", "/api/login", authenticate);

            server.Map("GET", "/api/routing/groups", getAllGroups);
            server.Map("DELETE", "/api/routing/groups/{id}", deleteGroup);
        }
    }
}
