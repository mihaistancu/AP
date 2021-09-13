using Microsoft.Owin;
using System.IO;

namespace AP.Service.WebApi
{
    public class Input
    {
        private readonly IOwinRequest request;

        public Input(IOwinRequest request)
        {
            this.request = request;
        }

        public string GetUrl()
        {
            return request.Uri.AbsolutePath;
        }

        public Stream GetBody()
        {
            return request.Body;
        }
    }
}
