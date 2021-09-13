using AP.Processing;
using AP.Processing.Sync.TlsCertificateValidation;

namespace AP.AS4
{
    public class As4TlsCertificateValidationErrorFactory : ITlsCertificateValidationErrorFactory
    {
        public Message Get(string validationMessage)
        {
            return new Message();
        }
    }
}
