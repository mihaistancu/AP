using AP.Processing.Sync;
using AP.Web.Server.Owin;

namespace AP.Messaging.Service
{
    public class MessageService : IWebService
    {
        private IHandler handler;

        public MessageService(IHandler handler)
        {
            this.handler = handler;
        }

        public void Handle(WebInput webInput, WebOutput webOutput)
        {
            var input = new MessageInput(webInput);
            var output = new MessageOutput(webOutput);
            var message = input.GetMessage();
            handler.Handle(message, output);
        }
    }
}
