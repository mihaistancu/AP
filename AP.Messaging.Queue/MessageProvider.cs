using AP.Handlers.PullRequest;

namespace AP.Messaging.Queue
{
    public class MessageProvider : IMessageProvider
    {
        private MessageQueue queue;

        public MessageProvider(MessageQueue queue)
        {
            this.queue = queue;
        }

        public Message Get(Message message)
        {
            return new Message();
        }
    }
}
