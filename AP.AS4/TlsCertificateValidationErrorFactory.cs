using AP.Handlers.TlsCertificateValidation;
using AP.Messaging;

namespace AP.AS4
{
    public class TlsCertificateValidationErrorFactory : ITlsCertificateValidationErrorFactory
    {
        public Message Get(string validationMessage)
        {
            return new Message();
        }
    }
}
