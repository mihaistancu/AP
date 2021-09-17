using AP.Processing;
using AP.Processing.Sync;
using AP.Processing.Sync.PullRequest;

namespace AP.Inbox
{
    public class Inbox : IInbox
    {
        private Queue queue;

        public Inbox(Queue queue)
        {
            this.queue = queue;
        }

        public Message Get(Message message)
        {
            return new Message();
        }
    }
}
