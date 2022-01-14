using AP.Handlers;
using AP.Messages;
using Microsoft.AspNetCore.Http;

namespace AP.Ingestion
{
    public class MessageOutput : IOutput
    {
        private HttpResponse response; 
        public MessageOutput(HttpResponse response)
        {
            this.response = response;
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
