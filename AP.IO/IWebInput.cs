using System.IO;

namespace AP.IO
{
    public interface IWebInput
    {
        Stream GetBody();
        string GetPath();
        string Get(string key);
    }
}