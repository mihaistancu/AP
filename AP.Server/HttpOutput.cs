using AP.Http;
using Microsoft.Owin;

namespace AP.Server
{
    public class HttpOutput : IHttpOutput
    {
        private IOwinResponse response;

        public HttpOutput(IOwinResponse response)
        {
            this.response = response;
        }

        public void Send(byte[] bytes)
        {
            response.Write(bytes);
        }

        public void ContentType(string contentType)
        {
            response.ContentType = contentType;
        }

        public void Status(int status)
        {
            response.StatusCode = status;
        }
    }
}
