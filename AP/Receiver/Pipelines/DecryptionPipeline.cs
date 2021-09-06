using AP.Receiver.Handlers;

namespace AP.Receiver.Pipelines
{
    public class DecryptionPipeline: Pipeline
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
