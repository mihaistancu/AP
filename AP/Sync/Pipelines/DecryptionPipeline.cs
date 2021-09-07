using AP.Sync.Handlers;
using AP.Sync.Handlers.Validation;

namespace AP.Sync.Pipelines
{
    public class DecryptionPipeline : Pipeline
    {
        public DecryptionPipeline(
            TlsCheckHandler tlsCheck,
            DecryptionHandler decryption,
            ValidationHandler validation,
            PersistenceHandler persistence)
            : base(tlsCheck, decryption, validation, persistence)
        {
        }
    }
}
