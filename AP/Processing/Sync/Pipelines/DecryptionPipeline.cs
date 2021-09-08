using AP.Processing.Sync.Handlers;
using AP.Processing.Sync.Handlers.Validation;

namespace AP.Processing.Sync.Pipelines
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
