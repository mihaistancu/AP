using Microsoft.Owin;
using Microsoft.Owin.Hosting;
using Owin;
using System;
using System.Threading.Tasks;

namespace AP.Web.Server.Owin
{
    public class WebServer
    {
        private Router router;

        public WebServer(Router router)
        {
            this.router = router;
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
                router.Route(context.Request, context.Response);
            });
        }
    }
}
