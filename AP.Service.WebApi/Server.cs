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
                var input = new Input(context.Request);
                var output = new Output(context.Response);
                Handle(input, output);
            });
        }

        protected virtual void Handle(Input input, Output output)
        {
            var message = parser.Parse(input.GetBody());
            var pipeline = config.GetPipeline(input.GetUrl());
            pipeline.Process(message, output);
        }
    }
}
