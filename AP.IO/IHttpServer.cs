using System;

namespace AP.IO
{
    public interface IHttpServer
    {
        void Map(string method, string path, IHttpHandler service);
        IDisposable Start(string url);
    }
}