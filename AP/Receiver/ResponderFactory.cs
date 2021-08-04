using AP.Receiver.Responders;

namespace AP.Receiver
{
    public class ResponderFactory
    {   
        private IResponder receiptAndError = new ReceiptAndErrorResponder();
        private IResponder errorOnly = new ErrorOnlyResponder();

        public IResponder Create(UseCase useCase)
        {
            if (useCase == UseCase.System)
            {
                return receiptAndError;
            }
            return errorOnly;
        }
    }
}
