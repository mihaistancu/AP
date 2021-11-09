using System;

namespace AP.Http
{
    public interface IHttpServer
    {
        void Map(string method, string path, HttpHandler handle);

        IDisposable Start(string url);
    }
}