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
            Map(server, "/Business/Inbound", 
                Handler.ValidateTlsCertificate,
                Handler.Decrypt,
                Handler.ValidateEnvelope,
                Handler.Persist,
                Handler.ProcessAsync);

            Map(server, "/Business/Outbox", 
                Handler.ValidateTlsCertificate,
                Handler.ValidateSignature,
                Handler.ValidateEnvelope,
                Handler.Persist,
                Handler.ProcessAsync);

            Map(server, "/Business/Inbox", 
                Handler.ValidateTlsCertificate,
                Handler.ValidateSignature,
                Handler.ValidateEnvelope,
                Handler.PullRequest);

            Map(server, "/System/Inbound", 
                Handler.ValidateTlsCertificate,
                Handler.ValidateSignature,
                Handler.ValidateEnvelope,
                Handler.Persist,
                Handler.ProcessAsync,
                Handler.Receipt);

            Map(server, "/System/Outbox", 
                Handler.ValidateTlsCertificate,
                Handler.ValidateSignature,
                Handler.ValidateEnvelope,
                Handler.Persist,
                Handler.ProcessAsync,
                Handler.Receipt);

            Map(server, "/System/Inbox", 
                Handler.ValidateTlsCertificate,
                Handler.ValidateSignature,
                Handler.ValidateEnvelope,
                Handler.PullRequest);
        }

        private void Map(IHttpServer server, string path, params string[] pipeline)
        {
            server.Map("POST", path, (httpInput, httpOutput) =>
            {
                var input = new MessageInput(httpInput);
                var output = new MessageOutput(httpOutput);
                Process(input, output, pipeline);
            }, AllowAll);
        }

        private void Process(MessageInput input, MessageOutput output, params string[] pipeline)
        {
            var message = input.GetMessage();
            var handlers = pipeline.Select(factory.Get);

            foreach (var handler in handlers)
            {
                handler.Handle(message, output);

                if (output.IsMessageSent()) return;
            }
        }

        private bool AllowAll(IHttpInput input)
        {
            return true;
        }
    }
}
