using AP.Messaging;

namespace AP.Handlers.TlsCertificateValidation
{
    public class TlsCertificateValidationHandler : IHandler
    {
        private ICertificateValidator validator;
        private ITlsCertificateValidationErrorFactory errorFactory;

        public TlsCertificateValidationHandler(
            ICertificateValidator validator,
            ITlsCertificateValidationErrorFactory errorFactory)
        {
            this.validator = validator;
            this.errorFactory = errorFactory;
        }

        public virtual void Handle(Message message, IOutput output)
        {
            var result = validator.Validate(message.Certificate);
            if (!result.IsSuccessful)
            {
                var error = errorFactory.Get(result.Message);
                output.Send(error);
            }
        }
    }
}
