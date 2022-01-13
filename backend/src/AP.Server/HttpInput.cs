using AP.Http;
using Microsoft.Owin;
using System.Collections.Generic;
using System.IO;

namespace AP.Server
{
    public class HttpInput : IHttpInput
    {
        private Dictionary<string, string> parameters;
        private IOwinRequest request;

        public HttpInput(Dictionary<string, string> parameters, IOwinRequest request)
        {
            this.parameters = parameters;
            this.request = request;
        }

        public string GetPath()
        {
            return request.Uri.AbsolutePath;
        }

        public Stream GetBody()
        {
            return request.Body;
        }

        public string Get(string key)
        {
            return parameters[key];
        }

        public string GetCookie(string key)
        {
            return request.Cookies[key];
        }
    }
}
