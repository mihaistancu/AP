using System.IO;

namespace AP.IO
{
    public interface IHttpInput
    {
        Stream GetBody();
        string GetPath();
        string Get(string key);
    }
}