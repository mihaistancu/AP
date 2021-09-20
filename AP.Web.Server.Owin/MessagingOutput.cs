using AP.Processing;
using AP.Processing.Sync;
using Microsoft.Owin;

namespace AP.Web.Server.Owin
{
    public class MessagingOutput : IOutput
    {
        private IOwinResponse response;
        private bool isMessageSent;

        public MessagingOutput(IOwinResponse response)
        {
            this.response = response;
        }

        public bool IsMessageSent()
        {
            return isMessageSent;
        }

        public void Send(Message message)
        {
            response.Write("");
            isMessageSent = true;
        }
    }
}
