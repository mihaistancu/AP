using AP.Processing;
using Microsoft.Owin;

namespace AP.Web.Server.Owin
{
    public class Input
    {
        private IOwinRequest request;

        public Input(IOwinRequest request)
        {
            this.request = request;
        }

        public Message GetMessage()
        {
            return new Message
            {
                Url = GetUrl(),
                DocumentType = "SYN001"
            };
        }

        public string GetUrl()
        {
            return request.Uri.AbsolutePath;
        }
    }
}
