using AP.Receiver.Handlers;

namespace AP.Receiver.Pipelines
{
    public class BusinessInboundPipeline: Pipeline
    {
        public BusinessInboundPipeline(
            TlsCheckHandler tlsCheck,
            DecryptionHandler decryption,
            ValidationHandler validation,
            PersistenceHandler persistence)
        {
            Add(tlsCheck);
            Add(decryption);
            Add(validation);
            Add(persistence);
        }
    }
}
