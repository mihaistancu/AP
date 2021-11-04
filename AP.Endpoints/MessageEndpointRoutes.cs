using AP.Http;
using System;
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
            server.Map("POST", "/Business/Inbound", Execute(
                Handler.ValidateTlsCertificate,
                Handler.Decrypt,
                Handler.ValidateEnvelope,
                Handler.Persist,
                Handler.ProcessAsync));

            server.Map("POST", "/Business/Outbox", Execute(
                Handler.ValidateTlsCertificate,
                Handler.ValidateSignature,
                Handler.ValidateEnvelope,
                Handler.Persist,
                Handler.ProcessAsync));

            server.Map("POST", "/Business/Inbox", Execute(
                Handler.ValidateTlsCertificate,
                Handler.ValidateSignature,
                Handler.ValidateEnvelope,
                Handler.PullRequest));

            server.Map("POST", "/System/Inbound", Execute(
                Handler.ValidateTlsCertificate,
                Handler.ValidateSignature,
                Handler.ValidateEnvelope,
                Handler.Persist,
                Handler.ProcessAsync,
                Handler.Receipt));

            server.Map("POST", "/System/Outbox", Execute(
                Handler.ValidateTlsCertificate,
                Handler.ValidateSignature,
                Handler.ValidateEnvelope,
                Handler.Persist,
                Handler.ProcessAsync,
                Handler.Receipt));

            server.Map("POST", "/System/Inbox", Execute(
                Handler.ValidateTlsCertificate,
                Handler.ValidateSignature,
                Handler.ValidateEnvelope,
                Handler.PullRequest));
        }

        public Action<IHttpInput, IHttpOutput> Execute(params string[] pipeline)
        {
            return (IHttpInput httpInput, IHttpOutput httpOutput) =>
            {
                var input = new MessageInput(httpInput);
                var output = new MessageOutput(httpOutput);
                var message = input.GetMessage();
                var handlers = pipeline.Select(factory.Get);

                foreach (var handler in handlers)
                {
                    handler.Handle(message, output);

                    if (output.IsMessageSent()) return;
                }
            };
        }
    }
}
