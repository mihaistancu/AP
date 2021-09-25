using AP.Handlers;
using AP.Web.Server;

namespace AP.Messaging.Service
{
    public class MessageOutput : IOutput
    {
        public MessageOutput(IWebOutput output)
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
