using AP.Processing;
using AP.Processing.Async.CDM.Request;

namespace AP.CDM
{
    public class CdmProvider<T> : ICdmProvider where T: IGateway
    {
        private CdmRequestParser parser;
        private CdmStorage cdmStorage;
        private IMessageStorage messageStorage;
        private T gateway;

        public CdmProvider(
            CdmRequestParser parser,
            CdmStorage cdmStorage,
            IMessageStorage messageStorage,
            T gateway)
        {
            this.parser = parser;
            this.cdmStorage = cdmStorage;
            this.messageStorage = messageStorage;
            this.gateway = gateway;
        }

        public void Respond(Message message)
        {
            var request = parser.Parse(message);
            var messages = cdmStorage.Get(request);
            messageStorage.Save(messages);
            gateway.Deliver(message);
        }
    }
}
