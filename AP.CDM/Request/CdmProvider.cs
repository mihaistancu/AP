using AP.Gateways.CSN;
using AP.Processing;
using AP.Processing.Async.Synchronization.CDM.Request;

namespace AP.CDM
{
    public class CdmProvider: ICdmProvider
    {
        private CdmRequestParser parser;
        private CdmStorage cdmStorage;
        private IMessageStorage messageStorage;
        private CsnGateway gateway;

        public CdmProvider(
            CdmRequestParser parser,
            CdmStorage cdmStorage,
            IMessageStorage messageStorage,
            CsnGateway gateway)
        {
            this.parser = parser;
            this.cdmStorage = cdmStorage;
            this.messageStorage = messageStorage;
            this.gateway = gateway;
        }

        public void Respond(Message message)
        {
            var request = parser.Parse(message);
            var newMessage = cdmStorage.Get(request);
            messageStorage.Save(newMessage);
            gateway.Deliver(newMessage);
        }
    }
}
