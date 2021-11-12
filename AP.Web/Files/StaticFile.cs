using AP.Http;
using System.IO;
using System.Reflection;

namespace AP.Web.Files
{
    public class StaticFile
    {
        public static bool Exists(string relativePath)
        {
            return File.Exists(FullPath(relativePath));
        }

        public static void Serve(string relativePath, IHttpOutput output)
        {
            var bytes = File.ReadAllBytes(FullPath(relativePath));
            output.Send(bytes);
        }

        private static string FullPath(string relativePath)
        {
            return Path.Combine(ExecutableRoot, relativePath);
        }

        private static string ExecutableRoot => Path.GetDirectoryName(ExecutablePath);

        private static string ExecutablePath => Assembly.GetExecutingAssembly().Location;
    }
}