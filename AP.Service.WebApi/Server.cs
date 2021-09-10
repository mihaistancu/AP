using Microsoft.Owin;
using Microsoft.Owin.Hosting;
using Owin;
using System;
using System.Threading.Tasks;

namespace AP.Service.WebApi
{
    public class Server
    {
        private IServerConfig config;
        private Parser parser;

        public Server(IServerConfig config, Parser parser)
        {
            this.config = config;
            this.parser = parser;
        }

        public IDisposable Start()
        {
            return WebApp.Start(config.GetServerUrl(), OnStart);
        }

        private void OnStart(IAppBuilder appBuilder)
        {
            appBuilder.Run(Handle);
        }

        private async Task Handle(IOwinContext context)
        {
            await Task.Run(() =>
            {
                try
                {
                    var message = parser.Parse(context.Request.Body);
                    var output = new Output(context.Response);
                    var url = context.Request.Uri.AbsolutePath;
                    var pipeline = config.GetPipeline(url);
                    pipeline.Process(message, output);
                }
                catch(Exception exception)
                {

                }
                
            });
        }
    }
}
