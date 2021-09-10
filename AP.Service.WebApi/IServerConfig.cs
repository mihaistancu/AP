using AP.Processing.Sync;

namespace AP.Service.WebApi
{
    public interface IServerConfig
    {
        string GetServerUrl();
        Pipeline GetPipeline(string url);
    }
}
