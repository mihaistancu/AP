using AP.Messaging.Service;
using AP.Processing.Sync;
using AP.Web.Server;
using System;

namespace AP.Host.Console
{
    public class MessagingServer
    {
        private IWebServer server;
        private Handlers handlers;

        public MessagingServer(IWebServer server, Handlers handlers)
        {
            this.server = server;
            this.handlers = handlers;
        }

        public IDisposable Start()
        {
            Map("/Business/Inbound", new Pipeline(
                handlers.ValidateTlsCertificate,
                handlers.Decrypt,
                handlers.ValidateEnvelope,
                handlers.Persist,
                handlers.ProcessAsync));

            Map("/Business/Outbox", new Pipeline(
                handlers.ValidateTlsCertificate,
                handlers.ValidateSignature,
                handlers.ValidateEnvelope,
                handlers.Persist,
                handlers.ProcessAsync));

            Map("/Business/Inbox", new Pipeline(
                handlers.ValidateTlsCertificate,
                handlers.ValidateSignature,
                handlers.ValidateEnvelope,
                handlers.PullRequest));

            Map("/System/Inbound", new Pipeline(
                handlers.ValidateTlsCertificate,
                handlers.ValidateSignature,
                handlers.ValidateEnvelope,
                handlers.Persist,
                handlers.ProcessAsync,
                handlers.Receipt));

            Map("/System/Outbox", new Pipeline(
                handlers.ValidateTlsCertificate,
                handlers.ValidateSignature,
                handlers.ValidateEnvelope,
                handlers.Persist,
                handlers.ProcessAsync,
                handlers.Receipt));

            Map("/System/Inbox", new Pipeline(
                handlers.ValidateTlsCertificate,
                handlers.ValidateSignature,
                handlers.ValidateEnvelope,
                handlers.PullRequest));

            return server.Start("http://localhost:9000");
        }

        private void Map(string url, Pipeline pipeline)
        {
            server.Map("POST", url, new MessageService(pipeline));
        }
    }
}
