using AP.Gateways;
using AP.Handlers.PullRequest;
using AP.Messages;

namespace AP.Queue
{
    public class MessageProvider : IMessageProvider
    {
        private IMessageQueue queue;

        public MessageProvider(IMessageQueue queue)
        {
            this.queue = queue;
        }

        public Message Get(Message message)
        {
            return new Message();
        }
    }
}
