using AP.Handlers.TlsCertificateValidation;
using AP.Messages;

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
