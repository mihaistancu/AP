using System;

namespace AP.Web.Server.Owin
{
    public class Route
    {
        public string Method { get; set; }
        public string Path { get; set; }
        public IWebService Service { get; set; }

        public bool Matches(string url, string path)
        {
            return true;
        }
    }
}
