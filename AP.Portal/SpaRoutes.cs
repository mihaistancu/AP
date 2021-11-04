using AP.Http;
using System.IO;

namespace AP.Configuration
{
    public class SpaRoutes
    {  
        public void Apply(IHttpServer server)
        {
            server.Map("GET", "/*", new GetStaticFile());
            server.Map("GET", "/", new GetDefaultFile());
        }

        public class GetStaticFile : GetFromPath, IHttpHandler
        {
            public void Handle(IHttpInput input, IHttpOutput output)
            {
                Handle(input.GetPath(), output);
            }
        }

        public class GetDefaultFile : GetFromPath, IHttpHandler
        {
            public void Handle(IHttpInput input, IHttpOutput output)
            {
                Handle("index.html", output);
            }
        }

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
