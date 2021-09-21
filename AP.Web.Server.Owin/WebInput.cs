using Microsoft.Owin;

namespace AP.Web.Server.Owin
{
    public class WebInput
    {
        private string routePath;
        private IOwinRequest request;

        public string GetUrl()
        {
            return request.Uri.AbsolutePath;
        }

        public WebInput(string routePath, IOwinRequest request)
        {
            this.routePath = routePath;
            this.request = request;
        }
    }
}
