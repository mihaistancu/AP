using AP.Processing;
using AP.Processing.Sync.EnvelopeValidation;

namespace AP.AS4
{
    public class As4EnvelopeValidationErrorFactory : IEnvelopeValidationErrorFactory
    {
        public Message Get(string validationMessage)
        {
            return new Message();
        }
    }
}
