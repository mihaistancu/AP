using AP.Handlers.Receipt;
using AP.Messages;

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
