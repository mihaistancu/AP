using AP.Http;
using AP.Instrumentation;
using System;

namespace AP.Server
{
    public class MonitoredHttpServer : IHttpServer
    {
        private ITrace trace;
        private IHttpServer server;

        private int requestCount = 0;

        public MonitoredHttpServer(ITrace trace, IMetrics metrics, IHttpServer server)
        {
            this.trace = trace;
            this.server = server;
            metrics.Observe("request-count", () => requestCount);
        }

        public void Map(string method, string path, HttpHandler handle)
        {
            server.Map(method, path, (input, output) =>
            {
                using (trace.Start("Handle Request"))
                {
                    requestCount++;
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
