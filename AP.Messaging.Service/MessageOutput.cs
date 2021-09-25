using AP.Handlers;
using AP.IO;
using AP.Messages;

namespace AP.Server
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
