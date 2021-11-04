using System;

namespace AP.Http
{
    public interface IHttpServer
    {
        void Map(string method, string path, IHttpHandler service);
        IDisposable Start(string url);
    }
}