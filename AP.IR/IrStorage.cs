using AP.IR.Request;
using AP.IR.Subscriptions;
using AP.Processing;
using AP.Processing.Async.IR.Import;
using AP.Routing.Config;

namespace AP.IR
{
    public class IrStorage: IIrImporter, ICsnConfig, IInstitutionConfig
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

        public bool IsCsn(string endpointId)
        {
            return false;
        }

        public string GetUrl(string endpointId)
        {
            return string.Empty;
        }

        public bool IsExternalInstitution(string endpointId)
        {
            return false;
        }
    }
}
