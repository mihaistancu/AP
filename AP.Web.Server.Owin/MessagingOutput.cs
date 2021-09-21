using AP.Processing;
using AP.Processing.Sync;

namespace AP.Web.Server.Owin
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
