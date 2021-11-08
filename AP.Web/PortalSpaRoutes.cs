using AP.Authorization;
using AP.Http;
using System.IO;

namespace AP.Web
{
    public partial class PortalSpaRoutes
    {
        private FileServer server;
        private Authorizer authorizer;

        public PortalSpaRoutes(FileServer server, Authorizer authorizer)
        {
            this.server = server;
            this.authorizer = authorizer;
        }

        public void Apply(IHttpServer server)
        {
            server.Map("GET", "/", ServeIndexPage, authorizer.AllowAuthenticated);
            server.Map("GET", "/*", ServePageByPath, authorizer.AllowAuthenticated);
        }

        private void ServeIndexPage(IHttpInput input, IHttpOutput output) 
        {
            server.Serve(FromPortal("index.html"), output);
        }

        private void ServePageByPath(IHttpInput input, IHttpOutput output)
        {
            server.Serve(FromPortal(input.GetPath()), output);
        }

        private string FromPortal(string path)
        {
            return Path.Combine("portal", path.Trim('/'));
        }
    }
}
