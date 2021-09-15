namespace AP.Processing.Sync.TlsCertificateValidation
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

        public virtual (bool, Message) Handle(Message message)
        {
            var result = validator.Validate(message.Certificate);
            if (!result.IsSuccessful)
            {
                var error = errorFactory.Get(result.Message);
                return (false, error);
            }
            return (true, null);
        }
    }
}
