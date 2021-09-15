using AP.Processing.Sync;
using AP.Web.Server.Owin;
using System;

namespace AP.Monitoring
{
    public class MonitoringWebServer<T> : WebServer<T> where T: IService
    {
        public MonitoringWebServer(T service) : base(service)
        {
        }

        protected override void Handle(IInput input, IOutput output)
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
