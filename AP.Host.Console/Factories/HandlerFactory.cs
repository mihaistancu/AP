using AP.AS4;
using AP.Certificates;
using AP.Cryptography;
using AP.Messaging.Queue;
using AP.Messaging.Service;
using AP.Monitoring;
using AP.Processing.Async;
using AP.Processing.Sync;
using AP.Processing.Sync.AsyncProcessing;
using AP.Processing.Sync.Decryption;
using AP.Processing.Sync.EnvelopeValidation;
using AP.Processing.Sync.Persistence;
using AP.Processing.Sync.PullRequest;
using AP.Processing.Sync.Receipt;
using AP.Processing.Sync.SignatureValidation;
using AP.Processing.Sync.TlsCertificateValidation;
using AP.Signing;
using AP.Storage;
using AP.Validation;
using System;
using System.Collections.Generic;

namespace AP.Host.Console
{
    public class HandlerFactory
    {
        private Dictionary<string, IHandler> cache = new Dictionary<string, IHandler>();
        private Dictionary<string, Func<IHandler>> factories = new Dictionary<string, Func<IHandler>>();

        public HandlerFactory(
            Orchestrator orchestrator, 
            MessageStorage messageStorage, 
            MessageQueue messageQueue)
        {
            factories[Handlers.ProcessAsync] = 
                () => new MonitoredHandler(
                    new AsyncProcessingHandler(orchestrator));

            factories[Handlers.Decrypt] =
                () => new MonitoredHandler(
                    new DecryptionHandler(new Decryptor()));

            factories[Handlers.ValidateEnvelope] =
                () => new MonitoredHandler(
                    new EnvelopeValidationHandler(
                        new EnvelopeValidator(), 
                        new EnvelopeValidationErrorFactory()));

            factories[Handlers.Persist] =
                () => new MonitoredHandler(
                    new PersistenceHandler(messageStorage));

            factories[Handlers.PullRequest] =
                () => new MonitoredHandler(
                    new PullRequestHandler(
                        new MessageProvider(messageQueue)));
                
            factories[Handlers.Receipt] = 
                () => new MonitoredHandler(
                    new ReceiptHandler(
                        new ReceiptFactory()));

            factories[Handlers.ValidateSignature] =
                () => new MonitoredHandler(
                    new SignatureValidationHandler(
                        new EnvelopeSignatureValidator(),
                        new EnvelopeSignatureValidationErrorFactory()));

            factories[Handlers.ValidateTlsCertificate] =
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
