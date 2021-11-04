using AP.Http;

namespace AP.Web
{
    public partial class StaticFileRoutes
    {  
        public void Apply(IHttpServer server)
        {
            server.Map("GET", "/*", new GetStaticFile());
            server.Map("GET", "/", new GetDefaultFile());
        }
    }
}
