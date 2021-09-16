using System.IO;

namespace AP.Processing.Sync
{
    public interface IInput
    {
        Stream GetBody();
        string GetMethod();
        string GetUrl();
    }
}
