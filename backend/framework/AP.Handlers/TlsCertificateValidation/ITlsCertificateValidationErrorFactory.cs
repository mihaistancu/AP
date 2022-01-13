using AP.Messages;

namespace AP.Handlers.TlsCertificateValidation
{
    public interface ITlsCertificateValidationErrorFactory
    {
        Message Get(string validationMessage);
    }
}
