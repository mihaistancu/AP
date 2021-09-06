using AP.Sync.Handlers;

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
