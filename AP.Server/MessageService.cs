using AP.Handlers;
using AP.IO;
using System.Collections.Generic;

namespace AP.Server
{
    public class MessageService : IHttpHandler
    {
        private IEnumerable<IHandler> handlers;

        public MessageService(IEnumerable<IHandler> handlers)
        {
            this.handlers = handlers;
        }

        public void Handle(IHttpInput httpInput, IHttpOutput httpOutput)
        {
            var input = new MessageInput(httpInput);
            var output = new MessageOutput(httpOutput);
            var message = input.GetMessage();

            foreach (var handler in handlers)
            {
                handler.Handle(message, output);

                if (output.IsMessageSent()) return;
            }
        }
    }
}
