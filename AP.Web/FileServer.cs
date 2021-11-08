using AP.Http;
using System.IO;
using System.Reflection;

namespace AP.Web
{
    public class FileServer
    {   
        public void Serve(string relativePath, IHttpOutput output)
        {
            var path = Path.Combine(ExecutableRoot, relativePath);
            var bytes = File.ReadAllBytes(path);
            output.Send(bytes);
        }

        private static string ExecutableRoot => Path.GetDirectoryName(ExecutablePath);

        private static string ExecutablePath => Assembly.GetExecutingAssembly().Location;
    }
}
