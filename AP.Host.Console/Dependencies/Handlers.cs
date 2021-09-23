using AP.Monitoring;
using AP.Processing.Sync;
using AP.Processing.Sync.AsyncProcessing;
using AP.Processing.Sync.Decryption;
using AP.Processing.Sync.EnvelopeValidation;
using AP.Processing.Sync.Persistence;
using AP.Processing.Sync.PullRequest;
using AP.Processing.Sync.Receipt;
using AP.Processing.Sync.SignatureValidation;
using AP.Processing.Sync.TlsCertificateValidation;

namespace AP.Host.Console
{
    public class Handlers
    {
        public IHandler ProcessAsync { get; private set; }
        public IHandler Decrypt { get; private set; }
        public IHandler ValidateEnvelope { get; private set; }
        public IHandler Persist { get; private set; }
        public IHandler PullRequest { get; private set; }
        public IHandler Receipt { get; private set; }
        public IHandler ValidateSignature { get; private set; }
        public IHandler ValidateTlsCertificate { get; private set; }

        public Handlers(
            AsyncProcessingHandler startAsyncWorkflow,
            DecryptionHandler decrypt,
            EnvelopeValidationHandler validateEnvelope,
            PersistenceHandler persist,
            PullRequestHandler pullRequest,
            ReceiptHandler receipt,
            SignatureValidationHandler validateSignature,
            TlsCertificateValidationHandler validateTlsCertificate)
        {
            ProcessAsync = new MonitoredHandler(startAsyncWorkflow);
            Decrypt = new MonitoredHandler(decrypt);
            ValidateEnvelope = new MonitoredHandler(validateEnvelope);
            Persist = new MonitoredHandler(persist);
            PullRequest = new MonitoredHandler(pullRequest);
            Receipt = new MonitoredHandler(receipt);
            ValidateSignature = new MonitoredHandler(validateSignature);
            ValidateTlsCertificate = new MonitoredHandler(validateTlsCertificate);
        }
    }
}
