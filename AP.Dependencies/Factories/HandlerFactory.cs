using AP.AS4;
using AP.Certificates;
using AP.Cryptography;
using AP.Endpoints;
using AP.Handlers;
using AP.Handlers.AsyncProcessing;
using AP.Handlers.Decryption;
using AP.Handlers.EnvelopeValidation;
using AP.Handlers.Persistence;
using AP.Handlers.PullRequest;
using AP.Handlers.Receipt;
using AP.Handlers.SignatureValidation;
using AP.Handlers.TlsCertificateValidation;
using AP.Monitoring;
using AP.Queue;
using AP.Server;
using AP.Signing;
using AP.Validation;
using System;
using System.Collections.Generic;

namespace AP.Dependencies.Factories
{
    public class HandlerFactory: IHandlerFactory
    {
        private Dictionary<string, IHandler> cache = new Dictionary<string, IHandler>();
        private Dictionary<string, Func<IHandler>> factories = new Dictionary<string, Func<IHandler>>();

        public HandlerFactory()
        {
            factories[Handler.ProcessAsync] =
                () => new MonitoredHandler(
                    new AsyncProcessingHandler(Context.Orchestrator));

            factories[Handler.Decrypt] =
                () => new MonitoredHandler(
                    new DecryptionHandler(new Decryptor()));

            factories[Handler.ValidateEnvelope] =
                () => new MonitoredHandler(
                    new EnvelopeValidationHandler(
                        new EnvelopeValidator(),
                        new EnvelopeValidationErrorFactory()));

            factories[Handler.Persist] =
                () => new MonitoredHandler(
                    new PersistenceHandler(Context.MessageStorage));

            factories[Handler.PullRequest] =
                () => new MonitoredHandler(
                    new PullRequestHandler(
                        new MessageProvider(Context.MessageQueue)));

            factories[Handler.Receipt] =
                () => new MonitoredHandler(
                    new ReceiptHandler(
                        new ReceiptFactory()));

            factories[Handler.ValidateSignature] =
                () => new MonitoredHandler(
                    new SignatureValidationHandler(
                        new EnvelopeSignatureValidator(),
                        new EnvelopeSignatureValidationErrorFactory()));

            factories[Handler.ValidateTlsCertificate] =
                    () => new MonitoredHandler(
                        new TlsCertificateValidationHandler(
                            new CertificateValidator(),
                            new TlsCertificateValidationErrorFactory()));
        }

        public IHandler Get(string name)
        {
            if (!cache.ContainsKey(name))
            {
                cache[name] = factories[name].Invoke();
            }
            return cache[name];
        }
    }
}
