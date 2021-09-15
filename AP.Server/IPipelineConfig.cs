using AP.Processing.Sync;

namespace AP.Server
{
    public interface IPipelineConfig
    {
        Pipeline GetPipeline(string url);
    }
}
