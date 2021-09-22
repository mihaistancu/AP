using AP.Processing;
using AP.Processing.Sync;
using AP.Web.Server.Owin;

namespace AP.Messaging.Service
{
    public class MessageOutput : IOutput
    {
        public MessageOutput(WebOutput output)
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
