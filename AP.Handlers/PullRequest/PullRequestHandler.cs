using AP.Messages;

namespace AP.Handlers.PullRequest
{
    public class PullRequestHandler : IHandler
    {
        private IMessageProvider provider;

        public PullRequestHandler(IMessageProvider provider)
        {
            this.provider = provider;
        }

        public void Handle(Message message, IOutput output)
        {
            var newMessage = provider.Get(message);
            output.Send(newMessage);
        }
    }
}
