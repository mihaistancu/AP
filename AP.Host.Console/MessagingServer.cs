using AP.Messaging.Server;
using AP.Processing.Sync;
using AP.Processing.Sync.AsyncProcessing;
using AP.Processing.Sync.Decryption;
using AP.Processing.Sync.EnvelopeValidation;
using AP.Processing.Sync.Persistence;
using AP.Processing.Sync.PullRequest;
using AP.Processing.Sync.Receipt;
using AP.Processing.Sync.SignatureValidation;
using AP.Processing.Sync.TlsCertificateValidation;
using AP.Web.Server.Owin;
using System;

namespace AP.Host.Console
{
    public class MessagingServer
    {
        private WebServer server;
        private Store store;

        public MessagingServer(WebServer server, Store store)
        {
            this.server = server;
            this.store = store;
        }

        public IDisposable Start()
        {
            Map("/Business/Inbound", new Pipeline(
                store.Get<TlsCertificateValidationHandler>(),
                store.Get<DecryptionHandler>(),
                store.Get<EnvelopeValidationHandler>(),
                store.Get<PersistenceHandler>(),
                store.Get<AsyncProcessingHandler>()));

            Map("/Business/Outbox", new Pipeline(
                store.Get<TlsCertificateValidationHandler>(),
                store.Get<SignatureValidationHandler>(),
                store.Get<EnvelopeValidationHandler>(),
                store.Get<PersistenceHandler>(),
                store.Get<AsyncProcessingHandler>()));

            Map("/Business/Inbox", new Pipeline(
                store.Get<TlsCertificateValidationHandler>(),
                store.Get<SignatureValidationHandler>(),
                store.Get<EnvelopeValidationHandler>(),
                store.Get<PullRequestHandler>()));

            Map("/System/Inbound", new Pipeline(
                store.Get<TlsCertificateValidationHandler>(),
                store.Get<SignatureValidationHandler>(),
                store.Get<EnvelopeValidationHandler>(),
                store.Get<PersistenceHandler>(),
                store.Get<AsyncProcessingHandler>(),
                store.Get<ReceiptHandler>()));

            Map("/System/Outbox", new Pipeline(
                store.Get<TlsCertificateValidationHandler>(),
                store.Get<SignatureValidationHandler>(),
                store.Get<EnvelopeValidationHandler>(),
                store.Get<PersistenceHandler>(),
                store.Get<AsyncProcessingHandler>(),
                store.Get<ReceiptHandler>()));

            Map("/System/Inbox", new Pipeline(
                store.Get<TlsCertificateValidationHandler>(),
                store.Get<SignatureValidationHandler>(),
                store.Get<EnvelopeValidationHandler>(),
                store.Get<PullRequestHandler>()));

            return server.Start("http://localhost:9000");
        }

        private void Map(string url, IHandler handler)
        {
            server.Map("POST", url, new MessageService(handler));
        }
    }
}
