using AP.Handlers.Receipt;
using AP.Messaging;

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
