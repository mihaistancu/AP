using System.IO;

namespace AP.Http
{
    public interface IHttpInput
    {
        Stream GetBody();
        string GetPath();
        string Get(string key);
    }
}