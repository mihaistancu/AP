using AP.Processing;
using AP.Processing.Sync.SignatureValidation;

namespace AP.AS4
{
    public class As4EnvelopeSignatureValidationErrorFactory : IEnvelopeSignatureValidationErrorFactory
    {
        public Message Get(string validationMessage)
        {
            return new Message();
        }
    }
}
