using AP.Gateways.AP;
using AP.Gateways.CSN;
using AP.IR.Request;
using AP.IR.Subscriptions;
using AP.Processing;
using AP.Processing.Async.Synchronization.IR.Import;

namespace AP.IR
{
    public class IrStorage: IIrImporter, ICsnConfig, IApConfig
    {
        public void Import(Message message)
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

        public string GetCsnUrl()
        {
            return string.Empty;
        }

        public string GetApUrl(string institutionId)
        {
            return string.Empty;
        }
    }
}
