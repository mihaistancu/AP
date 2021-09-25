using AP.Messaging.Queue;
using AP.Messaging.Service;
using AP.Orchestration;
using AP.Storage;
using AP.Web.Server.Owin;

namespace AP.Host.Console
{
    public class MessageServerFactory
    {
        private Orchestrator orchestrator;
        private MessageStorage messageStorage;
        private MessageQueue messageQueue;

        public MessageServerFactory(
            Orchestrator orchestrator, 
            MessageStorage messageStorage, 
            MessageQueue messageQueue)
        {
            this.orchestrator = orchestrator;
            this.messageStorage = messageStorage;
            this.messageQueue = messageQueue;
        }

        public MessageServer Get()
        {
            var handlerFactory = new HandlerFactory(orchestrator, messageStorage, messageQueue);

            return new MessageServer(new OwinWebServer(), handlerFactory.Get);
        }
    }
}
