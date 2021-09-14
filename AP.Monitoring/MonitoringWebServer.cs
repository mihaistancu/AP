using AP.Service.WebApi;
using System;

namespace AP.Monitoring
{
    public class MonitoringWebServer : WebServer
    {
        public MonitoringWebServer(
            IServerConfig config, 
            Parser parser) 
            : base(config, parser)
        {
        }

        protected override void Handle(Input input, Output output)
        {
            try
            {
                base.Handle(input, output);
            }
            catch(Exception exception)
            {
                Console.WriteLine(exception);
            }
        }
    }
}
