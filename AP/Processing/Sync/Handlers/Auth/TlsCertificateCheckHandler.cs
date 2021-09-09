using AP.Data;

namespace AP.Processing.Sync.Handlers.Auth
{
    public class TlsCertificateCheckHandler : IHandler
    {
        private readonly ICertificateValidator validator;

        public TlsCertificateCheckHandler(ICertificateValidator validator)
        {
            this.validator = validator;
        }

        public virtual bool Handle(Message message)
        {
            validator.Validate(message.Certificate);
            return true;
        }
    }
}
