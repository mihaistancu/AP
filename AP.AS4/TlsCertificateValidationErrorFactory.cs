using AP.Processing;
using AP.Processing.Sync.TlsCertificateValidation;

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
