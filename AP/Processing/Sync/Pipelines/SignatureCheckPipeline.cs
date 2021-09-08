using AP.Processing.Sync.Handlers;
using AP.Processing.Sync.Handlers.Validation;

namespace AP.Processing.Sync.Pipelines
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
