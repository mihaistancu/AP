using AP.Receiver.Controllers;
using Microsoft.Owin;
using Microsoft.Owin.Hosting;
using Owin;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace AP.Receiver.WebApi
{
    public class Server
    {
        private Dictionary<string, Controller> routes;

        public Server(
            BusinessInboundController businessInbound,
            BusinessOutboxController businessOutbox,
            SystemController system)
        {
            routes = new Dictionary<string, Controller>
            {
                {"/Business/Inbound", businessInbound },
                {"/Business/Outbox", businessOutbox },
                {"/System", system }
            };
        }

        public IDisposable Start()
        {
            return WebApp.Start("http://localhost:9000", OnStart);
        }

        private void OnStart(IAppBuilder appBuilder)
        {
            appBuilder.Run(Handle);
        }

        private async Task Handle(IOwinContext context)
        {
            var message = Parse(context.Request);
            var controller = routes[context.Request.Uri.AbsolutePath];
            var result = controller.Handle(message);
            await context.Response.WriteAsync(result);
        }

        private Message Parse(IOwinRequest request)
        {
            var memoryStream = new MemoryStream();
            request.Body.CopyTo(memoryStream);
            return new Message
            {
                Content = memoryStream.ToArray()
            };
        }
    }
}
