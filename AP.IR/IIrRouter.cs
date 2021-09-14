using AP.IR.Request;
using AP.IR.Subscriptions;
using AP.Processing;

namespace AP.IR
{
    public interface IIrRouter
    {
        void Route(IrRequest request, Message message);
        void Route(IrSubscription subscription, Message message);
    }
}
