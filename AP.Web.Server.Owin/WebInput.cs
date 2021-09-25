using AP.IO;
using Microsoft.Owin;
using System.Collections.Generic;
using System.IO;

namespace AP.Https
{
    public class WebInput : IWebInput
    {
        private Dictionary<string, string> parameters;
        private IOwinRequest request;

        public string GetUrl()
        {
            return request.Uri.AbsolutePath;
        }

        public Stream GetBody()
        {
            return request.Body;
        }

        public WebInput(Dictionary<string, string> parameters, IOwinRequest request)
        {
            this.parameters = parameters;
            this.request = request;
        }

        public string Get(string key)
        {
            return parameters[key];
        }
    }
}
