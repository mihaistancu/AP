using System;

namespace AP.Web.Server.Owin
{
    public class Route
    {
        public string Method { get; set; }
        public string Path { get; set; }
        public Action<Input, Output> Handler { get; set; }

        public Route(string method, string path, Action<Input, Output> handler)
        {
            Method = method;
            Path = path;
            Handler = handler;
        }

        public bool Matches(string url, string path)
        {
            return true;
        }
    }
}
