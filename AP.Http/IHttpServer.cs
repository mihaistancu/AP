using System;

namespace AP.Http
{
    public interface IHttpServer
    {
        void Map(string method, string path, Action<IHttpInput, IHttpOutput> execute);
        IDisposable Start(string url);
    }
}