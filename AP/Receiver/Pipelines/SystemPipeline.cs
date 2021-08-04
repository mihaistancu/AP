using AP.Receiver.Handlers;

namespace AP.Receiver.Pipelines
{
    public class SystemPipeline: Pipeline
    {
        public SystemPipeline(
            TlsCheckHandler tlsCheck,
            SignatureCheckHandler signatureCheck,
            ValidationHandler validation,
            PersistenceHandler persistence)
        {
            Add(tlsCheck);
            Add(signatureCheck);
            Add(validation);
            Add(persistence);
        }
    }
}
