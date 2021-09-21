using AP.Web.Server.Owin;

namespace AP.Messaging.Server
{
    public class MessagingServer : WebServer
    {
        private IMessagingServerConfig config;

        public MessagingServer(IMessagingServerConfig config, Router router) : base(router)
        {            
            this.config = config;
        }

        public void Start()
        {
            router.Add(new Route("POST", "*", Handle));
            Start(config.GetBaseUrl());
        }

        private void Handle(Input input, Output output)
        {
            var messagingInput = new MessagingInput(input);
            var messagingOutput = new MessagingOutput(output);
            var handler = config.Get(input.GetUrl());
            handler.Handle(messagingInput.GetMessage(), messagingOutput);
        }
    }
}
