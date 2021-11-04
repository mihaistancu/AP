using AP.IO;
using AP.Messages;

namespace AP.Server
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
