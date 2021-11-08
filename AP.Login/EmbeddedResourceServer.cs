using AP.Http;
using System.IO;
using System.Reflection;

namespace AP.Login
{
    public class EmbeddedResourceServer
    {
        public void Serve(string resourceName, IHttpOutput output)
        {
            var bytes = GetBytes(GetPath(resourceName));
            output.Send(bytes);
        }

        private string GetPath(string resourceName)
        {
            return GetType().Namespace + "." + resourceName;
        }

        private byte[] GetBytes(string resourcePath)
        {
            using (Stream stream = GetResource(resourcePath))
            {
                var memoryStream = new MemoryStream();
                stream.CopyTo(memoryStream);
                return memoryStream.ToArray();
            }
        }

        private Stream GetResource(string resourcePath)
        {   
            return Assembly
                .GetExecutingAssembly()
                .GetManifestResourceStream(resourcePath);
        }
    }
}
