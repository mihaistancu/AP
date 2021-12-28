using AP.Http;
using AP.Instrumentation;
using System;

namespace AP.Server
{
    public class MonitoredHttpServer : IHttpServer
    {
        private ITrace trace;
        private IHttpServer server;

        public MonitoredHttpServer(ITrace trace, IHttpServer server)
        {
            this.trace = trace;
            this.server = server;
        }

        public void Map(string method, string path, HttpHandler handle)
        {
            server.Map(method, path, (input, output) =>
            {
                using (trace.Start("Handle Request"))
                {
                    handle(input, output);
                }
            });
        }

        public IDisposable Start(string url)
        {
            return server.Start(url);
        }
    }
}
