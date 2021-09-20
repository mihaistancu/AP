using AP.Processing;
using Microsoft.Owin;

namespace AP.Web.Server.Owin
{
    public class MessagingInput
    {
        private IOwinRequest request;

        public MessagingInput(IOwinRequest request)
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
