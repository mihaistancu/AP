using AP.Http;
using AP.Messages;

namespace AP.Endpoints
{
    public class MessageInput
    {
        private IHttpInput input;

        public MessageInput(IHttpInput input)
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

        public string GetPath()
        {
            return input.GetPath();
        }
    }
}
