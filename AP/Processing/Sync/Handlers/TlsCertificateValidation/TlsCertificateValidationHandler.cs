﻿using AP.Data;

namespace AP.Processing.Sync.Handlers.TlsCertificateValidation
{
    public class TlsCertificateValidationHandler : IHandler
    {
        private readonly ICertificateValidator validator;

        public TlsCertificateValidationHandler(ICertificateValidator validator)
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
