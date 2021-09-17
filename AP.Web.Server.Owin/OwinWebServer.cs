using Microsoft.Owin;
using Microsoft.Owin.Hosting;
using Owin;
using System;
using System.Threading.Tasks;

namespace AP.Web.Server.Owin
{
    public class OwinWebServer
    {
        private IServerConfig config;

        public OwinWebServer(IServerConfig config)
        {
            this.config = config;
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
            await Task.Run(() =>
            {
                var input = new Input(context.Request);
                var output = new Output(context.Response);
                var service = config.Get(input.GetUrl());
                service.Handle(input.GetMessage(), output);
            });
        }
    }
}
