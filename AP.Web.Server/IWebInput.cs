using System.IO;

namespace AP.Web.Server
{
    public interface IWebInput
    {
        Stream GetBody();
        string GetUrl();
        string Get(string key);
    }
}