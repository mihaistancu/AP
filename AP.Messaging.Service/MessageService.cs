using AP.Processing.Sync;
using AP.Web.Server;

namespace AP.Messaging.Service
{
    public class MessageService : IWebService
    {
        private IHandler handler;

        public MessageService(IHandler handler)
        {
            this.handler = handler;
        }

        public void Handle(IWebInput webInput, IWebOutput webOutput)
        {
            var input = new MessageInput(webInput);
            var output = new MessageOutput(webOutput);
            var message = input.GetMessage();
            handler.Handle(message, output);
        }
    }
}
