using AP.Messages;

namespace AP.Handlers.Receipt
{
    public class ReceiptHandler : IHandler
    {
        private IReceiptFactory receiptFactory;

        public ReceiptHandler(IReceiptFactory receiptFactory)
        {
            this.receiptFactory = receiptFactory;
        }

        public void Handle(Message message, IOutput output)
        {
            var receipt = receiptFactory.Get(message);
            output.Send(receipt);
        }
    }
}
