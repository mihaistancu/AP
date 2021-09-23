using AP.Processing;
using AP.Web.Server;

namespace AP.Messaging.Service
{
    public class MessageInput
    {
        private IWebInput input;

        public MessageInput(IWebInput input)
        {
            this.input = input;
        }

        public Message GetMessage()
        {
            return new Message
            {
                UseCase = UseCase.System,
                Domain = Domain.International,
                DocumentType = "SYN001",
                EnvelopeType = EnvelopeType.UserMessage
            };
        }

        public string GetUrl()
        {
            return input.GetUrl();
        }
    }
}
