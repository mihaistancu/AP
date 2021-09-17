namespace AP.Processing.Sync.PullRequest
{
    public class PullRequestHandler : IHandler
    {
        private IInbox queue;

        public PullRequestHandler(IInbox queue)
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
