using AP.Data;
using AP.Processing.Async.DocumentValidation;

namespace AP.AS4
{
    public class As4DocumentValidationErrorFactory : IDocumentValidationErrorFactory
    {
        public Message Get(string validationMessage)
        {
            return new Message();
        }
    }
}
