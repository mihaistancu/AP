using AP.Processing;
using AP.Processing.Sync;
using AP.Web.Server.Owin;

namespace AP.Messaging.Server
{
    public class MessagingOutput : IOutput
    {
        public MessagingOutput(Output output)
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
