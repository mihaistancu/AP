using AP.Http;

namespace AP.Web.Routes
{
    public partial class SpaRoutes
    {
        private HttpHandler serveSpa;

        public SpaRoutes(HttpHandler serveSpa)
        {
            this.serveSpa = serveSpa;
        }

        public void Apply(IHttpServer server)
        {
            server.Map("GET", "*", serveSpa);
        }
    }
}
