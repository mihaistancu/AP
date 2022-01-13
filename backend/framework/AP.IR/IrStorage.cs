using AP.Gateways.AP;
using AP.Gateways.CSN;
using AP.IR.Request;
using AP.IR.Subscriptions;
using AP.Messages;

namespace AP.IR
{
    public class IrStorage
    {
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
