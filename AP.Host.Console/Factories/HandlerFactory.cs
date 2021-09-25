using AP.AS4;
using AP.Certificates;
using AP.Cryptography;
using AP.Handlers;
using AP.Handlers.AsyncProcessing;
using AP.Handlers.Decryption;
using AP.Handlers.EnvelopeValidation;
using AP.Handlers.Persistence;
using AP.Handlers.PullRequest;
using AP.Handlers.Receipt;
using AP.Handlers.SignatureValidation;
using AP.Handlers.TlsCertificateValidation;
using AP.Messaging.Queue;
using AP.Messaging.Service;
using AP.Monitoring;
using AP.Orchestration;
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
            factories[Handler.ProcessAsync] = 
                () => new MonitoredHandler(
                    new AsyncProcessingHandler(orchestrator));

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
                    new PersistenceHandler(messageStorage));

            factories[Handler.PullRequest] =
                () => new MonitoredHandler(
                    new PullRequestHandler(
                        new MessageProvider(messageQueue)));
                
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
