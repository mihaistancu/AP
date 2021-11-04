using AP.Handlers;
using AP.Http;
using AP.Messages;

namespace AP.Endpoints
{
    public class MessageOutput : IOutput
    {
        public MessageOutput(IHttpOutput output)
        {

        }

        private bool isMessageSent;

        public bool IsMessageSent()
        {
            return isMessageSent;
        }

        public void Send(Message message)
        {
            isMessageSent = true;
        }
    }
}
