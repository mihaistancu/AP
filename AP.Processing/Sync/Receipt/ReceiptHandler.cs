namespace AP.Processing.Sync.Receipt
{
    public class ReceiptHandler : IHandler
    {
        private IReceiptFactory receiptFactory;

        public ReceiptHandler(IReceiptFactory receiptFactory)
        {
            this.receiptFactory = receiptFactory;
        }

        public (bool, Message) Handle(Message message)
        {
            var receipt = receiptFactory.Get(message);
            return (false, receipt);
        }
    }
}
