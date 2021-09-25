using AP.Handlers.EnvelopeValidation;
using AP.Messaging;

namespace AP.AS4
{
    public class EnvelopeValidationErrorFactory : IEnvelopeValidationErrorFactory
    {
        public Message Get(string validationMessage)
        {
            return new Message();
        }
    }
}
