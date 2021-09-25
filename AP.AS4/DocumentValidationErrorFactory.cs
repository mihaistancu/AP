using AP.Messaging;
using AP.Workers.DocumentValidation;

namespace AP.AS4
{
    public class DocumentValidationErrorFactory : IDocumentValidationErrorFactory
    {
        public Message Get(string validationMessage)
        {
            return new Message();
        }
    }
}
