using AP.Web.Server.Owin;

namespace AP.Messaging.Server
{
    public class MessagingService : IWebService
    {
        private IMessagingEndpointConfig config;

        public MessagingService(IMessagingEndpointConfig config)
        {
            this.config = config;
        }

        public void Handle(WebInput input, WebOutput output)
        {
            var messagingInput = new MessagingInput(input);
            var messagingOutput = new MessagingOutput(output);
            var handler = config.Get(input.GetUrl());
            handler.Handle(messagingInput.GetMessage(), messagingOutput);
        }
    }
}
