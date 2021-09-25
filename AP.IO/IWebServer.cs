using System;

namespace AP.IO
{
    public interface IWebServer
    {
        void Map(string method, string path, IWebService service);
        IDisposable Start(string url);
    }
}