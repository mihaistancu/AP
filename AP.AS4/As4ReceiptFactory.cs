using AP.Data;
using AP.Signals;

namespace AP.AS4.ReceiptFactories
{
    public class As4ReceiptFactory : IReceiptFactory
    {
        public Message Get(Message message)
        {
            return new Message();
        }
    }
}
