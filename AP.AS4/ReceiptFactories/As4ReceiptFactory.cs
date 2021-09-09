using AP.Data;
using AP.Signals;

namespace AP.AS4.ReceiptFactories
{
    public class As4ReceiptFactory : IReceiptFactory
    {
        public string Get(Message message)
        {
            return "as4 receipt";
        }
    }
}
