using AP.Http;

namespace AP.Web.Routes
{
    public class ApiRoutes
    {
        private HttpHandler authenticate;

        public ApiRoutes(
            HttpHandler authenticate)
        {
            this.authenticate = authenticate;


        }

        public void Apply(IHttpServer server)
        {
            server.Map("POST", "/api/login", authenticate);

            
        }
    }
}
