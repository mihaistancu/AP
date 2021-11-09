using AP.Http;
using AP.Web.Files;

namespace AP.Web.Routes
{
    public partial class SpaRoutes
    {
        private HttpHandler serveSpaIndex;
        private HttpHandler serveSpaAssets;

        public SpaRoutes(HttpHandler serveSpaIndex, HttpHandler serveSpaAssets)
        {
            this.serveSpaIndex = serveSpaIndex;
            this.serveSpaAssets = serveSpaAssets;
        }

        public void Apply(IHttpServer server)
        {
            server.Map("GET", "/", serveSpaIndex);
            server.Map("GET", "/*", serveSpaAssets);
        }
    }
}
