using AP.IR.Request;
using AP.IR.Subscriptions;
using AP.Processing;

namespace AP.IR
{
    public class IrStorage
    {
        public void Save(Message message)
        {
            
        }

        public Message Get(IrRequest request)
        {
            return new Message();
        }

        public Message Get(IrSubscription subscription)
        {
            return new Message();
        }
    }
}
