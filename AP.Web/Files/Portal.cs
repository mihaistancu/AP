using AP.Http;
using System.IO;

namespace AP.Web.Files
{
    public class Portal
    {
        public static void ServeIndex(IHttpInput input, IHttpOutput output)
        {
            StaticFile.Serve(FromPortal("index.html"), output);
        }

        public static void ServeAsset(IHttpInput input, IHttpOutput output)
        {
            StaticFile.Serve(FromPortal(input.GetPath()), output);
        }

        private static string FromPortal(string path)
        {
            return Path.Combine("portal", path.Trim('/'));
        }
    }
}
