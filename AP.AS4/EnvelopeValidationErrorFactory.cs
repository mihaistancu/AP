using AP.Handlers.EnvelopeValidation;
using AP.Messages;

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
