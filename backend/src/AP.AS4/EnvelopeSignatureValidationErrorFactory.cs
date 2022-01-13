using AP.Handlers.SignatureValidation;
using AP.Messages;

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
