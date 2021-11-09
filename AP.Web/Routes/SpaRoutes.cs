using AP.Http;
using AP.Web.Files;

namespace AP.Web.Routes
{
    public partial class SpaRoutes
    {
        public void Apply(IHttpServer server)
        {
            server.Map("GET", "/", ServeIndex);
            server.Map("GET", "/*", Serve);
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
