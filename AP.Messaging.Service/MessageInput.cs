using AP.Processing;
using AP.Web.Server.Owin;

namespace AP.Messaging.Service
{
    public class MessageInput
    {
        private WebInput input;

        public MessageInput(WebInput input)
        {
            this.input = input;
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
            return input.GetUrl();
        }
    }
}
