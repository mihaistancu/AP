﻿using AP.Processing;
using AP.Processing.Sync.SignatureValidation;

namespace AP.AS4
{
    public class EnvelopeSignatureValidationErrorFactory : IEnvelopeSignatureValidationErrorFactory
    {
        public Message Get(string validationMessage)
        {
            return new Message();
        }
    }
}
