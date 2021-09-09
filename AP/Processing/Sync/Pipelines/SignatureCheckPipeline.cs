using AP.Processing.Sync.Handlers.Auth;
using AP.Processing.Sync.Handlers.SignatureCheck;
using AP.Processing.Sync.Handlers.Persistence;
using AP.Processing.Sync.Handlers.Validation;

namespace AP.Processing.Sync.Pipelines
{
    public class SignatureCheckPipeline : Pipeline
    {
        public SignatureCheckPipeline(
            TlsCertificateCheckHandler tlsCheck,
            SignatureValidationHandler signatureCheck,
            EnvelopeValidationHandler validation,
            PersistenceHandler persistence)
            : base(tlsCheck, signatureCheck, validation, persistence)
        {
        }
    }
}
