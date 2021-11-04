using AP.Handlers;
using AP.Http;
using System.Collections.Generic;

namespace AP.Endpoints
{
    public class MessageHandler : IHttpHandler
    {
        private IEnumerable<IHandler> handlers;

        public MessageHandler(IEnumerable<IHandler> handlers)
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
