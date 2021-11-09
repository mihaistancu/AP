using AP.Http;
using System.IO;

namespace AP.Web.Files
{
    public class Portal
    {
        public static void ServeIndex(IHttpOutput output)
        {
            StaticFile.Serve(FromPortal("index.html"), output);
        }

        public static void Serve(string path, IHttpOutput output)
        {
            StaticFile.Serve(FromPortal(path), output);
        }

        private static string FromPortal(string path)
        {
            return Path.Combine("portal", path.Trim('/'));
        }
    }
}
