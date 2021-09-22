using AP.Processing.Sync;
using AP.Web.Server.Owin;

namespace AP.Messaging.Server
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
            var input = new Input(webInput);
            var output = new Output(webOutput);
            var message = input.GetMessage();
            handler.Handle(message, output);
        }
    }
}
