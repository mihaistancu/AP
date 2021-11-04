using AP.IO;
using System.IO;

namespace AP.Configuration
{
    public class GetStaticFile: IWebHandler
    {
        private string root;

        public GetStaticFile(string root)
        {
            this.root = root;
        }

        public void Handle(IWebInput input, IWebOutput output)
        {
            var requestedPath = input.GetPath();
            var filePath = Path.Combine(root, requestedPath);
            var bytes = File.ReadAllBytes(filePath);
            output.Send(bytes);
        }
    }
}
