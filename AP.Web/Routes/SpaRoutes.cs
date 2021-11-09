using AP.Http;
using AP.Web.Authorization;
using AP.Web.Files;

namespace AP.Web.Routes
{
    public partial class SpaRoutes
    {
        private Authorizer authorizer;

        public SpaRoutes(Authorizer authorizer)
        {
            this.authorizer = authorizer;
        }

        public void Apply(IHttpServer server)
        {
            server.Map("GET", "/", ServeIndex, authorizer.AllowAuthenticated);
            server.Map("GET", "/*", Serve, authorizer.AllowAuthenticated);
        }

        private void ServeIndex(IHttpInput input, IHttpOutput output)
        {
            Portal.ServeIndex(output);
        }

        private void Serve(IHttpInput input, IHttpOutput output)
        {
            Portal.Serve(input.GetPath(), output);
        }
    }
}
