﻿using System;

namespace AP.Web.Server
{
    public interface IWebServer
    {
        void Map(string method, string path, IWebService service);
        IDisposable Start(string url);
    }
}