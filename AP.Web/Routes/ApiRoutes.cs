using AP.Http;

namespace AP.Web.Routes
{
    public class ApiRoutes
    {
        private HttpHandler authenticate;
        private HttpHandler getAllGroups;

        public ApiRoutes(
            HttpHandler authenticate, 
            HttpHandler getAllGroups)
        {
            this.authenticate = authenticate;
            this.getAllGroups = getAllGroups;
        }

        public void Apply(IHttpServer server)
        {
            server.Map("POST", "/api/login", authenticate);

            server.Map("GET", "/api/routing/groups", getAllGroups);
        }
    }
}
