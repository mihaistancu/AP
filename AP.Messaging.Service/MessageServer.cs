using AP.Host.Console;
using AP.Web.Server;
using System.Linq;

namespace AP.Messaging.Service
{
    public class MessageServer
    {
        private IWebServer server;
        private HandlerFactory factory;

        public MessageServer(IWebServer server, HandlerFactory factory)
        {
            this.server = server;
            this.factory = factory;
        }

        public void Start()
        {
            Map("/Business/Inbound",
                Handlers.ValidateTlsCertificate,
                Handlers.Decrypt,
                Handlers.ValidateEnvelope,
                Handlers.Persist,
                Handlers.ProcessAsync);

            Map("/Business/Outbox",
                Handlers.ValidateTlsCertificate,
                Handlers.ValidateSignature,
                Handlers.ValidateEnvelope,
                Handlers.Persist,
                Handlers.ProcessAsync);

            Map("/Business/Inbox",
                Handlers.ValidateTlsCertificate,
                Handlers.ValidateSignature,
                Handlers.ValidateEnvelope,
                Handlers.PullRequest);

            Map("/System/Inbound",
                Handlers.ValidateTlsCertificate,
                Handlers.ValidateSignature,
                Handlers.ValidateEnvelope,
                Handlers.Persist,
                Handlers.ProcessAsync,
                Handlers.Receipt);

            Map("/System/Outbox",
                Handlers.ValidateTlsCertificate,
                Handlers.ValidateSignature,
                Handlers.ValidateEnvelope,
                Handlers.Persist,
                Handlers.ProcessAsync,
                Handlers.Receipt);

            Map("/System/Inbox",
                Handlers.ValidateTlsCertificate,
                Handlers.ValidateSignature,
                Handlers.ValidateEnvelope,
                Handlers.PullRequest);

            server.Start("http://localhost:9000");
        }

        private void Map(string url, params string[] pipeline)
        {
            var handlers = pipeline.Select(factory.Get);
            server.Map("POST", url, new MessageService(handlers));
        }
    }
}
