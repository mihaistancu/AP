using AP.Configuration;
using AP.IO;
using System;

namespace AP.Portal
{
    public class PortalServer
    {
        private IWebServer server;
        private ApiRoutes routes;

        public PortalServer(IWebServer server, ApiRoutes routes)
        {
            this.server = server;
            this.routes = routes;
        }

        public IDisposable Start()
        {
            routes.Apply(server);

            server.Map("GET", "/*", new GetStaticFile("./dist"));

            return server.Start("http://localhost:9090");
        }
    }
}
