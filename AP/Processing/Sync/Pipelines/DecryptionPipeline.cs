using AP.Processing.Sync.Handlers.Auth;
using AP.Processing.Sync.Handlers.Decryption;
using AP.Processing.Sync.Handlers.Persistence;
using AP.Processing.Sync.Handlers.Validation;

namespace AP.Processing.Sync.Pipelines
{
    public class DecryptionPipeline : Pipeline
    {
        public DecryptionPipeline(
            TlsCertificateCheckHandler tlsCheck,
            DecryptionHandler decryption,
            EnvelopeValidationHandler validation,
            PersistenceHandler persistence)
            : base(tlsCheck, decryption, validation, persistence)
        {
        }
    }
}
