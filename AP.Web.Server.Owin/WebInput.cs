using Microsoft.Owin;
using System;
using System.IO;

namespace AP.Web.Server.Owin
{
    public class WebInput : IWebInput
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

        public string Params(string key)
        {
            var routeTokens = routePath.Split('/');
            var index = Array.IndexOf(routeTokens, $"{{{key}}}");
            var urlTokens = GetUrl().Split('/');
            return urlTokens[index];
        }
    }
}
