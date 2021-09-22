using AP.Processing.Sync;
using AP.Web.Server.Owin;

namespace AP.Messaging.Server
{
    public class MessagingService : IWebService
    {
        private IHandler handler;

        public MessagingService(IHandler handler)
        {
            this.handler = handler;
        }

        public void Handle(WebInput input, WebOutput output)
        {
            var messagingInput = new MessagingInput(input);
            var messagingOutput = new MessagingOutput(output);
            handler.Handle(messagingInput.GetMessage(), messagingOutput);
        }
    }
}
