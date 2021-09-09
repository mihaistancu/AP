using AP.Processing.Sync.Handlers.Persistence;
using AP.Processing.Sync.Handlers.EnvelopeValidation;
using AP.Processing.Sync.Handlers.SignatureValidation;
using AP.Processing.Sync.Handlers.TlsCertificateValidation;

namespace AP.Processing.Sync.Pipelines
{
    public class SignatureCheckPipeline : Pipeline
    {
        public SignatureCheckPipeline(
            TlsCertificateValidationHandler tlsCheck,
            SignatureValidationHandler signatureCheck,
            EnvelopeValidationHandler validation,
            PersistenceHandler persistence)
            : base(tlsCheck, signatureCheck, validation, persistence)
        {
        }
    }
}
