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
            server.Map("GET", "/", (input, output) => {
                Serve("index.html", output);
            });

            server.Map("GET", "/*", (input, output) => {
                Serve(input.GetPath(), output);
            });
        }

        private void Serve(string path, IHttpOutput output)
        {
            var filePath = Path.Combine(root, path.TrimStart('/'));
            var bytes = File.ReadAllBytes(filePath);
            output.Send(bytes);
        }
    }
}
