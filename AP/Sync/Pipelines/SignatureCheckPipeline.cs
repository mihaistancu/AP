using AP.Sync.Handlers;
using AP.Sync.Handlers.Validation;

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
