﻿using Microsoft.Owin;
using Microsoft.Owin.Hosting;
using Owin;
using System;
using System.Threading.Tasks;

namespace AP.Web.Server.Owin
{
    public class WebServer : IWebServer
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

        public void Map(string method, string path, IWebService service)
        {
            router.Add(new Route
            {
                Method = method,
                Path = path,
                Service = service
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
