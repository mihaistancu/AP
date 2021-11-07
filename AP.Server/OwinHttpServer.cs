using AP.Http;
using Microsoft.Owin;
using Microsoft.Owin.Hosting;
using Owin;
using System;
using System.Threading.Tasks;

namespace AP.Server
{
    public class OwinHttpServer : IHttpServer
    {
        private Router router = new Router();

        public IDisposable Start(string url)
        {
            return WebApp.Start(url, OnStart);
        }

        private void OnStart(IAppBuilder appBuilder)
        {
            appBuilder.Run(Handle);
        }

        public void Map(
            string method, 
            string path, 
            Action<IHttpInput, IHttpOutput> execute, 
            Func<IHttpInput, bool> isAuthorized)
        {
            router.Add(new Route
            {
                Method = method,
                Path = path,
                Execute = execute,
                IsAuthorized = isAuthorized
            });
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
