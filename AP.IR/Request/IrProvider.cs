using AP.Processing;
using AP.Processing.Async.IR.Request;

namespace AP.IR.Request
{
    public class IrProvider<T> : IIrProvider where T: IGateway
    {
        private IrRequestParser parser;
        private IrStorage irStorage;
        private IMessageStorage messageStorage;
        private T gateway;

        public IrProvider(
            IrRequestParser parser,
            IrStorage irStorage,
            IMessageStorage messageStorage,
            T gateway)
        {
            this.parser = parser;
            this.irStorage = irStorage;
            this.messageStorage = messageStorage;
            this.gateway = gateway;
        }

        public void Respond(Message message)
        {
            var request = parser.Parse(message);
            var newMessage = irStorage.Get(request);
            messageStorage.Save(newMessage);
            gateway.Deliver(newMessage);
        }
    }
}
