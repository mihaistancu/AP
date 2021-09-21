using AP.Processing.Sync;

namespace AP.Messaging.Server
{
    public interface IMessagingEndpointConfig
    {
        IHandler Get(string url);
    }
}
