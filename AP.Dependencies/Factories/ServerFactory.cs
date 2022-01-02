using AP.Http;
using AP.Server;

namespace AP.Dependencies.Factories
{
    public class ServerFactory
    {
        public IHttpServer Create()
        {
            return new MonitoredHttpServer(Context.Trace, Context.Metrics, new OwinHttpServer());
        }
    }
}
