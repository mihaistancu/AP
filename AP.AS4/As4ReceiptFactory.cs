using AP.Processing;
using AP.Processing.Sync.Receipt;

namespace AP.AS4
{
    public class As4ReceiptFactory : IReceiptFactory
    {
        public Message Get(Message message)
        {
            return new Message();
        }
    }
}
