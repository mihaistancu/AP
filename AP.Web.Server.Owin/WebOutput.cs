using AP.IO;
using Microsoft.Owin;

namespace AP.Https
{
    public class WebOutput : IWebOutput
    {
        private IOwinResponse response;

        public WebOutput(IOwinResponse response)
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
