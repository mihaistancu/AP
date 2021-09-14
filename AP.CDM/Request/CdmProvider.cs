using AP.Processing;
using AP.Processing.Async.CDM.Request;

namespace AP.CDM
{
    public class CdmProvider : ICdmProvider
    {
        private CdmRequestParser parser;
        private CdmStorage cdmStorage;
        private IMessageStorage messageStorage;
        private IRouter router;

        public CdmProvider(
            CdmRequestParser parser,
            CdmStorage cdmStorage,
            IMessageStorage messageStorage,
            IRouter router)
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
            router.Route(request.Requester, messages);
        }
    }
}
