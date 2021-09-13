using AP.Processing.Sync;
using AP.Processing.Sync.AsyncProcessing;
using AP.Processing.Sync.Decryption;
using AP.Processing.Sync.EnvelopeValidation;
using AP.Processing.Sync.Persistence;
using AP.Processing.Sync.Receipt;
using AP.Processing.Sync.SignatureValidation;
using AP.Processing.Sync.TlsCertificateValidation;
using AP.Service.WebApi;

namespace AP.Host.Console
{
    public class ServerConfig : IServerConfig
    {
        private Store store;

        public ServerConfig(Store store)
        {
            this.store = store;
        }

        public string GetServerUrl()
        {
            return "http://localhost:9000";
        }

        public Pipeline GetPipeline(string url)
        {
            switch (url)
            {
                case "/Business/Inbound": return new Pipeline(
                    store.Get<TlsCertificateValidationHandler>(),
                    store.Get<DecryptionHandler>(),
                    store.Get<EnvelopeValidationHandler>(),
                    store.Get<PersistenceHandler>(),
                    store.Get<AsyncProcessingHandler>());

                case "/Business/Outbox": return new Pipeline(
                    store.Get<TlsCertificateValidationHandler>(),
                    store.Get<SignatureValidationHandler>(),
                    store.Get<EnvelopeValidationHandler>(),
                    store.Get<PersistenceHandler>(),
                    store.Get<AsyncProcessingHandler>());

                case "/System/Inbound": return new Pipeline(
                    store.Get<TlsCertificateValidationHandler>(),
                    store.Get<SignatureValidationHandler>(),
                    store.Get<EnvelopeValidationHandler>(),
                    store.Get<PersistenceHandler>(),
                    store.Get<AsyncProcessingHandler>(),
                    store.Get<ReceiptHandler>());

                case "/System/Outbox": return new Pipeline(
                    store.Get<TlsCertificateValidationHandler>(),
                    store.Get<SignatureValidationHandler>(),
                    store.Get<EnvelopeValidationHandler>(),
                    store.Get<PersistenceHandler>(),
                    store.Get<AsyncProcessingHandler>(),
                    store.Get<ReceiptHandler>());
            }
            throw new System.Exception("Invalid url");
        }
    }
}
