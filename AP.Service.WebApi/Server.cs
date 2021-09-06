using Microsoft.Owin;
using Microsoft.Owin.Hosting;
using Owin;
using System;
using System.Threading.Tasks;

namespace AP.Service.WebApi
{
    public class Server
    {
        private readonly Router router;
        private readonly Parser parser;

        public Server(Router router, Parser parser)
        {
            this.router = router;
            this.parser = parser;
        }

        public IDisposable Start(string url)
        {
            return WebApp.Start(url, OnStart);
        }

        private void OnStart(IAppBuilder appBuilder)
        {
            appBuilder.Run(Handle);
        }

        private async Task Handle(IOwinContext context)
        {   
            var url = context.Request.Uri.AbsolutePath;
            var message = parser.Parse(context.Request.Body);
            var result = router.Route(url, message);
            await context.Response.WriteAsync(result);
        }
    }
}
