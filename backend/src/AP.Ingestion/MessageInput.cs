using AP.Messages;
using Microsoft.AspNetCore.Http;

namespace AP.Ingestion
{
    public class MessageInput
    {
        private HttpRequest request;

        public MessageInput(HttpRequest request)
        {
            this.request = request;
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
            return request.Path;
        }
    }
}
