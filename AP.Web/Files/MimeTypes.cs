using AP.Http;
using System.IO;

namespace AP.Web.Files
{
    public class MimeTypes
    {
        public static void Apply(string path, IHttpOutput output)
        {
            var extension = Path.GetExtension(path);

            switch(extension)
            {
                case ".js": output.ContentType("text/javascript"); break;
                case ".css": output.ContentType("text/css"); break;
            }
        }
    }
}
