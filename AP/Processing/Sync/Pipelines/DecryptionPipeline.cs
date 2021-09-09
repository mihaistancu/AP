using AP.Processing.Sync.Handlers.Decryption;
using AP.Processing.Sync.Handlers.EnvelopeValidation;
using AP.Processing.Sync.Handlers.Persistence;
using AP.Processing.Sync.Handlers.TlsCertificateValidation;

namespace AP.Processing.Sync.Pipelines
{
    public class DecryptionPipeline : Pipeline
    {
        public DecryptionPipeline(
            TlsCertificateValidationHandler tlsCheck,
            DecryptionHandler decryption,
            EnvelopeValidationHandler validation,
            PersistenceHandler persistence)
            : base(tlsCheck, decryption, validation, persistence)
        {
        }
    }
}
