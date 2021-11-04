using AP.Http;
using System.IO;

namespace AP.Web
{
    public partial class StaticFileRoutes
    {
        public class GetFromPath
        {
            public void Handle(string path, IHttpOutput output)
            {
                var filePath = Path.Combine("./dist", path);
                var bytes = File.ReadAllBytes(filePath);
                output.Send(bytes);
            }
        }
    }
}
