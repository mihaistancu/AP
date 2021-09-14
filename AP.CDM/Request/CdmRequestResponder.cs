using AP.Processing;
using AP.Processing.Async.CDM.Request;

namespace AP.CDM
{
    public class CdmRequestResponder : ICdmRequestResponder
    {
        private CdmRequestParser parser;
        private CdmStorage cdmStorage;
        private IMessageStorage messageStorage;
        private ICdmRouter router;

        public CdmRequestResponder(
            CdmRequestParser parser,
            CdmStorage cdmStorage,
            IMessageStorage messageStorage,
            ICdmRouter router)
        {
            this.parser = parser;
            this.cdmStorage = cdmStorage;
            this.messageStorage = messageStorage;
            this.router = router;
        }

        public void Respond(Message message)
        {
            var request = parser.Parse(message);
            var messages = cdmStorage.Get(request);
            messageStorage.Save(messages);
            router.Route(request, messages);
        }
    }
}
