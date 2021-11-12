using AP.Http;
using System.IO;

namespace AP.Web.Files
{
    public class Portal
    {
        private static string Index => FromPortal("index.html");

        public static void Serve(IHttpInput input, IHttpOutput output)
        {
            var path = FromPortal(input.GetPath());

            if (StaticFile.Exists(path))
            {
                StaticFile.Serve(path, output);
            }
            else
            {
                StaticFile.Serve(Index, output);
            }
        }
        
        private static string FromPortal(string path)
        {
            return Path.Combine("portal", path.Trim('/'));
        }
    }
}
