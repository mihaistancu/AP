using AP.Processing.Sync;
using Microsoft.Owin;
using System.IO;

namespace AP.Web.Server.Owin
{
    public class Input : IInput
    {
        private IOwinRequest request;

        public Input(IOwinRequest request)
        {
            this.request = request;
        }

        public string GetUrl()
        {
            return request.Uri.AbsolutePath;
        }

        public string GetMethod()
        {
            return request.Method;
        }

        public Stream GetBody()
        {
            return request.Body;
        }
    }
}
