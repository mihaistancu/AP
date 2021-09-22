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

        public bool Matches(string method, string url)
        {
            if (Method != method) return false;

            if (Path == url) return true;

            var pathTokens = Path.Split('/');
            var urlTokens = url.Split('/');

            if (pathTokens.Length != urlTokens.Length) return false;

            for (int i=0; i<pathTokens.Length; i++)
            {
                if (pathTokens[i].StartsWith("{") && pathTokens[i].EndsWith("}")) continue;

                if (pathTokens[i] != urlTokens[i]) return false;
            }

            return true;
        }
    }
}
