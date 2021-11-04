using AP.Http;
using System.Linq;

namespace AP.Endpoints
{
    public class MessageEndpointRoutes
    {
        private IHandlerFactory factory;

        public MessageEndpointRoutes(IHandlerFactory factory)
        {
            this.factory = factory;
        }

        public void Apply(IHttpServer server)
        {
            server.Map("POST", "/Business/Inbound", Map(
                Handler.ValidateTlsCertificate,
                Handler.Decrypt,
                Handler.ValidateEnvelope,
                Handler.Persist,
                Handler.ProcessAsync));

            server.Map("POST", "/Business/Outbox", Map(
                Handler.ValidateTlsCertificate,
                Handler.ValidateSignature,
                Handler.ValidateEnvelope,
                Handler.Persist,
                Handler.ProcessAsync));

            server.Map("POST", "/Business/Inbox", Map(
                Handler.ValidateTlsCertificate,
                Handler.ValidateSignature,
                Handler.ValidateEnvelope,
                Handler.PullRequest));

            server.Map("POST", "/System/Inbound", Map(
                Handler.ValidateTlsCertificate,
                Handler.ValidateSignature,
                Handler.ValidateEnvelope,
                Handler.Persist,
                Handler.ProcessAsync,
                Handler.Receipt));

            server.Map("POST", "/System/Outbox", Map(
                Handler.ValidateTlsCertificate,
                Handler.ValidateSignature,
                Handler.ValidateEnvelope,
                Handler.Persist,
                Handler.ProcessAsync,
                Handler.Receipt));

            server.Map("POST", "/System/Inbox", Map(
                Handler.ValidateTlsCertificate,
                Handler.ValidateSignature,
                Handler.ValidateEnvelope,
                Handler.PullRequest));
        }

        private MessageHandler Map(params string[] pipeline)
        {
            var handlers = pipeline.Select(factory.Get);
            return new MessageHandler(handlers);
        }
    }
}
