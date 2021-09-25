using AP.Handlers.SignatureValidation;
using AP.Messaging;

namespace AP.AS4
{
    public class EnvelopeSignatureValidationErrorFactory : IEnvelopeSignatureValidationErrorFactory
    {
        public Message Get(string validationMessage)
        {
            return new Message();
        }
    }
}
