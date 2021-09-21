using AP.Processing;

namespace AP.Web.Server.Owin
{
    public class MessagingInput
    {
        private Input input;

        public MessagingInput(Input input)
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
