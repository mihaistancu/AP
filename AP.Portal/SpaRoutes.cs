using AP.IO;
using System.IO;

namespace AP.Configuration
{
    public class SpaRoutes
    {  
        public void Apply(IWebServer server)
        {
            server.Map("GET", "/*", new GetStaticFile());
            server.Map("GET", "/", new GetDefaultFile());
        }

        public class GetStaticFile : GetFromPath, IWebHandler
        {
            public void Handle(IWebInput input, IWebOutput output)
            {
                Handle(input.GetPath(), output);
            }
        }

        public class GetDefaultFile : GetFromPath, IWebHandler
        {
            public void Handle(IWebInput input, IWebOutput output)
            {
                Handle("index.html", output);
            }
        }

        public class GetFromPath
        {
            public void Handle(string path, IWebOutput output)
            {
                var filePath = Path.Combine("./dist", path);
                var bytes = File.ReadAllBytes(filePath);
                output.Send(bytes);
            }
        }
    }
}
