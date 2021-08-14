using AP.Processing;
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
        private readonly WorkflowFactory factory;

        public Server(
            BusinessInboundController businessInbound,
            BusinessOutboxController businessOutbox,
            SystemController system,
            WorkflowFactory factory)
        {
            routes = new Dictionary<string, Controller>
            {
                {"/Business/Inbound", businessInbound },
                {"/Business/Outbox", businessOutbox },
                {"/System", system }
            };
            this.factory = factory;
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
            var workflow = factory.Get(message.SedType);
            workflow.Start(message);
            await context.Response.WriteAsync(result);
        }

        private Message Parse(IOwinRequest request)
        {
            var reader = new StreamReader(request.Body);
            var content = reader.ReadToEnd();
            return new Message
            {
                SedType = content,
                Content = content
            };
        }
    }
}
