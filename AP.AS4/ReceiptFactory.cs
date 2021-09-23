using AP.Processing;
using AP.Processing.Sync.Receipt;

namespace AP.AS4
{
    public class ReceiptFactory : IReceiptFactory
    {
        public Message Get(Message message)
        {
            return new Message();
        }
    }
}
