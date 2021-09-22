namespace AP.Web.Server.Owin
{
    public class Route
    {
        public string Method { get; set; }
        public string Path { get; set; }
        public IWebService Service { get; set; }

        public Route(string method, string path, IWebService service)
        {
            Method = method;
            Path = path;
            Service = service;
        }

        public bool Matches(string url, string path)
        {
            return true;
        }
    }
}
