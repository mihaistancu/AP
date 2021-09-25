using AP.Handlers;
using AP.Web.Server;
using System.Collections.Generic;

namespace AP.Messaging.Service
{
    public class MessageService : IWebService
    {
        private IEnumerable<IHandler> handlers;

        public MessageService(IEnumerable<IHandler> handlers)
        {
            this.handlers = handlers;
        }

        public void Handle(IWebInput webInput, IWebOutput webOutput)
        {
            var input = new MessageInput(webInput);
            var output = new MessageOutput(webOutput);
            var message = input.GetMessage();
            
            foreach (var handler in handlers)
            {
                handler.Handle(message, output);

                if (output.IsMessageSent()) return;
            }
        }
    }
}
