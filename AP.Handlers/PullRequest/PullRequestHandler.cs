using AP.Messages;

namespace AP.Handlers.PullRequest
{
    public class PullRequestHandler : IHandler
    {
        private IMessageProvider queue;

        public PullRequestHandler(IMessageProvider queue)
        {
            this.queue = queue;
        }

        public void Handle(Message message, IOutput output)
        {
            var newMessage = queue.Get(message);
            output.Send(newMessage);
        }
    }
}
