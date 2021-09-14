using AP.Processing;
using AP.Processing.Async.IR.Request;

namespace AP.IR.Request
{
    public class IrRequestResponder : IIrRequestResponder
    {
        private IrRequestParser parser;
        private IrStorage irStorage;
        private IMessageStorage messageStorage;
        private IIrRouter router;

        public IrRequestResponder(
            IrRequestParser parser,
            IrStorage irStorage,
            IMessageStorage messageStorage,
            IIrRouter router)
        {
            this.parser = parser;
            this.irStorage = irStorage;
            this.messageStorage = messageStorage;
            this.router = router;
        }

        public void Respond(Message message)
        {
            var request = parser.Parse(message);
            var newMessage = irStorage.Get(request);
            messageStorage.Save(newMessage);
            router.Route(request, newMessage);
        }
    }
}
