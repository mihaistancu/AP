using AP.Processing.Sync;
using Microsoft.Owin;
using Microsoft.Owin.Hosting;
using Owin;
using System;
using System.Threading.Tasks;

namespace AP.Web.Server.Owin
{
    public class WebServer<T> where T : IService
    {
        private T service;

        public WebServer(T service)
        {
            this.service = service;
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
                service.Handle(input, output);
            });
        }

        protected virtual void Handle(IInput input, IOutput output)
        {
            service.Handle(input, output);
        }
    }
}
