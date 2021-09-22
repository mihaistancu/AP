using Microsoft.Owin;
using System.IO;

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

        public Stream GetBody()
        {
            return request.Body;
        }

        public WebInput(string routePath, IOwinRequest request)
        {
            this.routePath = routePath;
            this.request = request;
        }
    }
}
