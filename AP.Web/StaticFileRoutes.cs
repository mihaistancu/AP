using AP.Http;
using System.IO;

namespace AP.Web
{
    public partial class StaticFileRoutes
    {
        private string root;

        public StaticFileRoutes(string root)
        {
            this.root = root;
        }

        public void Apply(IHttpServer server)
        {
            server.Map("GET", "/", ServeIndexPage, IsAuthorized);
            server.Map("GET", "/*", ServePageByPath, IsAuthorized);
        }

        private void ServeIndexPage(IHttpInput input, IHttpOutput output) 
        {
            Serve("index.html", output);
        }

        private void ServePageByPath(IHttpInput input, IHttpOutput output)
        {
            Serve(input.GetPath(), output);
        }

        private void Serve(string path, IHttpOutput output)
        {
            var filePath = Path.Combine(root, path.TrimStart('/'));
            var bytes = File.ReadAllBytes(filePath);
            output.Send(bytes);
        }

        private bool IsAuthorized(IHttpInput input)
        {
            return true;
        } 
    }
}
