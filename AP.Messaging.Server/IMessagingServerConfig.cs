using AP.Processing.Sync;

namespace AP.Messaging.Server
{
    public interface IMessagingServerConfig
    {
        string GetBaseUrl();
        IHandler Get(string url);
    }
}
