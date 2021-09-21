namespace AP.Web.Server.Owin
{
    public class MessagingServer: WebServer
    {
        private IMessagingServerConfig config;

        public MessagingServer(IMessagingServerConfig config, Router router) : base(router)
        {
            router.Add(new Route("POST", "*", Handle));
            this.config = config;
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
