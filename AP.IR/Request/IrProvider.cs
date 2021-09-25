using AP.Gateways.Institution;
using AP.Messaging;
using AP.Workers.Synchronization.IR.Request;

namespace AP.IR.Request
{
    public class IrProvider : IIrProvider
    {
        private IrRequestParser parser;
        private IrStorage irStorage;
        private IMessageStorage messageStorage;
        private InstitutionGateway gateway;

        public IrProvider(
            IrRequestParser parser,
            IrStorage irStorage,
            IMessageStorage messageStorage,
            InstitutionGateway gateway)
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
