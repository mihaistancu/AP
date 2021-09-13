namespace AP.Processing.Sync.Receipt
{
    public class ReceiptHandler : IHandler
    {
        private IReceiptFactory receiptFactory;

        public ReceiptHandler(IReceiptFactory receiptFactory)
        {
            this.receiptFactory = receiptFactory;
        }

        public bool Handle(Message message, IOutput output)
        {
            var receipt = receiptFactory.Get(message);
            output.Buffer(receipt);
            return true;
        }
    }
}
