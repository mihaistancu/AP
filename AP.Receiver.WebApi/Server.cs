using AP.Receiver.Controllers;
using Microsoft.Owin;
using Microsoft.Owin.Hosting;
using Owin;
using System;
using System.IO;
using System.Threading.Tasks;

namespace AP.Receiver.WebApi
{
    public class Server
    {
        private readonly BusinessInboundController businessInbound;
        private readonly BusinessOutboxController businessOutbox;
        private readonly SystemController system;

        public Server(
            BusinessInboundController businessInbound,
            BusinessOutboxController businessOutbox,
            SystemController system)
        {
            this.businessInbound = businessInbound;
            this.businessOutbox = businessOutbox;
            this.system = system;
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
            var controller = GetController(context.Request.Uri.AbsolutePath);
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

        private Controller GetController(string path)
        {
            if (path.Contains("Business\\Inbound"))
            {
                return businessInbound;
            }
            if (path.Contains("Business\\Outbox"))
            {
                return businessOutbox;
            }
            if (path.Contains("System"))
            {
                return system;
            }
            throw new Exception("No controller matches route");
        } 
    }
}
