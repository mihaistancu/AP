using AP.Http;
using System;
using System.Collections.Generic;

namespace AP.Server
{
    public class Route
    {
        public string Method { get; set; }
        public string Path { get; set; }
        public HttpHandler Handle { get; set; }

        public bool Matches(string method, string url, Dictionary<string, string> parameters)
        {
            if (Method != method) return false;

            if (Path == "*") return true;

            var pathTokens = Path.Split('/');
            var urlTokens = url.Split('/');

            if (pathTokens.Length != urlTokens.Length) return false;

            parameters.Clear();

            for (int i = 0; i < pathTokens.Length; i++)
            {
                if (pathTokens[i] == urlTokens[i])
                {
                    continue;
                }
                else if (pathTokens[i].StartsWith("{") && pathTokens[i].EndsWith("}"))
                {
                    var key = pathTokens[i].Substring(1, pathTokens[i].Length - 2);
                    parameters[key] = urlTokens[i];
                }
                else
                {
                    return false;
                }
            }
            return true;
        }
    }
}
