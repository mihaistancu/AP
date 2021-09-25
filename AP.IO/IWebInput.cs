using System.IO;

namespace AP.IO
{
    public interface IWebInput
    {
        Stream GetBody();
        string GetUrl();
        string Get(string key);
    }
}