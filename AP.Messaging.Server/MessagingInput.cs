using AP.Processing;
using AP.Web.Server.Owin;

namespace AP.Messaging.Server
{
    public class MessagingInput
    {
        private WebInput input;

        public MessagingInput(WebInput input)
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
