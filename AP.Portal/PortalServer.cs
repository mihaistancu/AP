using AP.Configuration;
using AP.IO;
using System;

namespace AP.Portal
{
    public class PortalServer
    {
        private IHttpServer server;
        private ApiRoutes apiRoutes;
        private SpaRoutes spaRoutes;

        public PortalServer(
            IHttpServer server, 
            ApiRoutes apiRoutes,
            SpaRoutes spaRoutes)
        {
            this.server = server;
            this.apiRoutes = apiRoutes;
            this.spaRoutes = spaRoutes;
        }

        public IDisposable Start()
        {
            apiRoutes.Apply(server);
            spaRoutes.Apply(server);

            return server.Start("http://localhost:9090");
        }
    }
}
