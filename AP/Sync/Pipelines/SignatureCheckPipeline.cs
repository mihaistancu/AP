using AP.Sync.Handlers;

namespace AP.Sync.Pipelines
{
    public class SignatureCheckPipeline : Pipeline
    {
        public SignatureCheckPipeline(
            TlsCheckHandler tlsCheck,
            SignatureCheckHandler signatureCheck,
            ValidationHandler validation,
            PersistenceHandler persistence)
            : base(tlsCheck, signatureCheck, validation, persistence)
        {
        }
    }
}
